    public partial class Page21 : ContentPage, INotifyPropertyChanged
    {
        private List<imageurl> _urls;
        public List<imageurl> urls
        {
            get { return _urls; }
            set
            {
                _urls = value;
                RaisePropertyChanged("urls");
              
            }
        }
        
        public Page21()
        {
            InitializeComponent();
            urls = new List<imageurl>();
            GetJSON();
            this.BindingContext = this;
        }
        public async void GetJSON()
        {
            var response = await client.GetAsync("REPLACE YOUR JSON URL");
            string stringJson = await response.Content.ReadAsStringAsync();
            urls= JsonConvert.DeserializeObject<List<imageurl>>(stringJson);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;    
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class imageurl
    {
        public string AbsoluteUri { get; set; }
    }
