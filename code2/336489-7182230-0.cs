    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // used to force databinding to refresh
        public int FakeProperty
        {
            get { return (int)GetValue(FakePropertyProperty); }
            set { SetValue(FakePropertyProperty, value); }
        }
        public static readonly DependencyProperty FakePropertyProperty =
            DependencyProperty.Register("FakeProperty", 
            typeof(int), typeof(MainWindow), new UIPropertyMetadata(0));
        private void TextBox_TextChanged(object sender, 
            System.Windows.Controls.TextChangedEventArgs e)
        {
            FakeProperty++;
        }
    }
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Family { get; set; }
        private int m_Value;
        public int Value
        {
            get { return m_Value; }
            set
            {
                if (m_Value == value)
                    return;
                m_Value = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }
    public class Items : ObservableCollection<Item>
    {
        public Items()
        {
            this.Add(new Item { Family = "One", Value = 1 });
            this.Add(new Item { Family = "One", Value = 2 });
            this.Add(new Item { Family = "Two", Value = 3 });
            this.Add(new Item { Family = "Two", Value = 4 });
            this.Add(new Item { Family = "Two", Value = 5 });
            this.Add(new Item { Family = "Three", Value = 6 });
            this.Add(new Item { Family = "Three", Value = 7 });
        }
    }
    public class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
                        object parameter, System.Globalization.CultureInfo culture)
        {
            var _Default = 0;
            if (values == null || values.Length != 2)
                return _Default;
            var _Collection = values[0] as System.Collections.IEnumerable;
            if (_Collection == null)
                return _Default;
            var _Items = _Collection.Cast<Item>();
            if (_Items == null)
                return _Default;
            var _Sum = _Items.Sum(x => x.Value);
            return _Sum;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, obje
                        ct parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
