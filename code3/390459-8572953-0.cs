    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        string json = "";
        private RootObject topic;
        public event PropertyChangedEventHandler PropertyChanged;
        public RootObject Topic 
        { 
            get
            {
                return this.topic;
            }
            set
            {
                this.topic = value;
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs("Topic"));
                }
            }
        }
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ...
        }
        public void Response_Completed(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                json = streamReader.ReadToEnd();
                this.Topic = JsonConvert.DeserializeObject<RootObject>(json);
            }
        }
    }
