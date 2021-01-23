    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
    public class ViewModel
    {
        public SliderValues slv { get; private set; }
        public ViewModel()
        {
            slv = new SliderValues();
        }
    }
    public class SliderValues : INotifyPropertyChanged
    {
        bool _isLocked = false;
        public bool IsLocked
        {
            get { return _isLocked; }
            set
            {
                _isLocked = value;
                OnPropertyChanged("IsLocked");
            }
        }
        int _theValue = 5;
        public int TheValue
        {
            get { return _theValue; }
            set
            {
                _theValue = value;
                OnPropertyChanged("TheValue");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
