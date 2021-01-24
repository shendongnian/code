    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ProfilViewModel model = new ProfilViewModel();
            BindingContext = model;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var RecordsList = new ObservableCollection<Record>();
            RecordsList.Add(new Record { Name = "e" });
            RecordsList.Add(new Record { Name = "f" });
            RecordsList.Add(new Record { Name = "g" });
            MessagingCenter.Send<ObservableCollection<Record>>(RecordsList, "update");
        }
    }
    public class ProfilViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Record> recordsList { get; set; }
        public ObservableCollection<Record> RecordsList
        {
            get { return recordsList; }
            set
            {
                recordsList = value;
                OnPropertyChanged("RecordsList");
            }  
        }
        public ProfilViewModel() {
            recordsList = new ObservableCollection<Record>();
            recordsList.Add(new Record { Name = "a" });
            recordsList.Add(new Record { Name = "b" });
            recordsList.Add(new Record { Name = "c" });
            MessagingCenter.Subscribe<ObservableCollection<Record>>(this, "update", (records) =>
            {
                RecordsList = records;
            });
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Record : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        string name { get; set; }
        public string Name
        {
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
            get
            {
                return name;
            }
        }
    }
