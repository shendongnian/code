        <ComboBox SelectedItem="{Binding SelectedNumber, Mode=OneWayToSource}"                   
                  ItemsSource="{Binding MyNumbers.Keys}"/>
        <TextBlock Text="{Binding MyNumberValue}" />
----
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            MyNumbers = new Dictionary<string, int> { { "Uno", 1 }, { "Dos", 2 }, { "Tres", 3 } };
            DataContext = this;   
        }
        public IDictionary<string, int> MyNumbers { get; set; }
        string _selectedNumber;
        public string SelectedNumber
        {
            get { return _selectedNumber; }
            set
            {
                _selectedNumber = value;
                Notify("SelectedNumber");
                UpdateMyNumberValue();
            }
        }
        int _myNumberValue;
        public int MyNumberValue
        {
            get { return _myNumberValue; }
            set 
            { 
                _myNumberValue = value;
                Notify("MyNumberValue");
            }
        }
        void UpdateMyNumberValue()
        {
            var key = SelectedNumber;
            if (key == null || !MyNumbers.ContainsKey(key)) return;
            new Thread(() =>
            {
                Thread.Sleep(3000);
                MyNumberValue = MyNumbers[key];
            }).Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string property)
        {
            var handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(property));
        }
    }
