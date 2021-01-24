    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        private bool isEnabled = false;
        public bool IsEnabled {
            get { return isEnabled; }
            set {
                isEnabled = value;
                OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public sealed partial class MainPage: Page
    {​
        public MainPage()​
        {​
            this.InitializeComponent();​
            MyViewModel = new ViewModel();
        }
        private ViewModel MyViewModel { get; set; }
    }
