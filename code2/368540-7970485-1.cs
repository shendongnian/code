    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = new VM();
        }
    
        private void NumberOfRes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Resident resident = comboBox.DataContext as Resident;
            int number = (int)comboBox.SelectedItem;
        }
    }
    
    public class VM
    {
        public VM()
        {
            Residents = new ObservableCollection<Resident>() { new Resident() { PersonName = "AAA" }, new Resident() { PersonName = "BBB" } };
        }
    
        public ObservableCollection<Resident> Residents { get; private set; }
    
        public IEnumerable<int> ListOfNums
        {
            get { return new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }; }
        }
    }
    
    public class Resident
    {
        public string PersonName { get; set; }
    }
