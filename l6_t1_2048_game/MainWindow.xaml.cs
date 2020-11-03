using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace l6_t1_2048_game
{
    public class CellValue : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(int value)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public static implicit operator int(CellValue obj)
        {
            return obj._value;
        }

        public static implicit operator CellValue(int newValue)
        {
            return new CellValue() { _value = newValue };
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; Notify(value); }
        }
        
        int _value;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int GRID_SIZE = 4;
        public ObservableCollection<ObservableCollection<CellValue>> GridValues { get; private set; }

       
        public MainWindow()
        {
            InitializeComponent();

            InitGridValues();

            this.DataContext = this;
        }

        private void InitGridValues()
        {
            GridValues = new ObservableCollection<ObservableCollection<CellValue>>(); ;

            for (int i = 0; i < GRID_SIZE; i++)
            {
                GridValues.Add( new ObservableCollection<CellValue>() );

                for(int j = 0; j < GRID_SIZE; j++)
                {
                    GridValues[i].Add(new CellValue() { Value = 0 });
                }
            }

            var rnd = new Random();
            GridValues[0][0] = (CellValue)2;
            GridValues[0][1] = (CellValue)4;

            
        }
    }
}
