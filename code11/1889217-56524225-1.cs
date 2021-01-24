    //Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        public BaseViewModel ViewModel { get; set; } = new BaseViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }
        static int k = 3;
        private void Button_Click(object sender, RoutedEventArgs e) //can also implement using ICommand instead of event
        {
            this.ViewModel.ModelItems.Add(new BaseModelItem { Index = k, Name = "Name" + ++k });
        }
    }
    //--------Model------------
    public class NotifyPropertyChanged : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyname));
        }
    }
    public class BaseModelItem : NotifyPropertyChanged
    {
        string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyRaised("Name"); }
        }
        int _index = 0;
        public int Index
        {
            get { return _index; }
            set { _index = value; OnPropertyRaised("Index"); }
        }
    }
    //--------ViewModel------------
    public class BaseViewModel
    {
        public System.Collections.ObjectModel.ObservableCollection<BaseModelItem> ModelItems { get; set; }
        public BaseViewModel()
        {
            ModelItems = new System.Collections.ObjectModel.ObservableCollection<BaseModelItem>();
            ModelItems.Add(new BaseModelItem() { Name = "Name 1", Index = 0 });
            ModelItems.Add(new BaseModelItem() { Name = "Name 2", Index = 1 });
            ModelItems.Add(new BaseModelItem() { Name = "Name 3", Index = 2 });
        }
    }
