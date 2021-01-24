    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            initUri();
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(15);
            timer.Tick += Timer_Tick;
            timer.Start();
    
        }
        private List<Uri> _uris = new List<Uri>();
        private void initUri()
        {
         
            _uris.Add(new Uri("xxxxx"));
            _uris.Add(new Uri("xxxxx"));
            _uris.Add(new Uri("xxxxx"));       
    
        }
    
        int count = 0;
        private void Timer_Tick(object sender, object e)
        {
    
            Source = _uris[count];
            count++;
            if (count == _uris.Count)
            {
                count = 0;
            }
        }
    
       
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Uri _source = new Uri("xxxxxx");
        public Uri Source
        {
            get
            {
                return _source;
            }
    
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }
    }
