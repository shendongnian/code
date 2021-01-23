    public partial class MainPage : UserControl
    {
        Random rand;
        public MainPage()
        {
            InitializeComponent();
            rand = new Random();
        }
        public void DownloadDataInBackground(int callId, Action<int> returnResult)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("https://www.google.com/search?q=" + callId.ToString());
            client.DownloadStringCompleted += (s, e) =>
            {
                // Do something else with result ?
                returnResult(e.Result.Length);
            };
            client.DownloadStringAsync(uri);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int callid=rand.Next();
            Debug.WriteLine("Executing CallID #{0}", callid);
            DownloadDataInBackground(callid, r =>
            {
                Debug.WriteLine("The result for the callid {0} is {1}", callid, r);
            }));
        }
    }
