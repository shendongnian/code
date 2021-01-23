    public partial class MainPage : UserControl
    {
        int rand;
        public MainPage()
        {
            InitializeComponent();
            rand = 0;
        }
        public Func<Action<int, int>, Action<int>> DownloadDataInBackground = (callback) =>
        {
            return (c) =>
            {
                WebClient client = new WebClient();
                Uri uri = new Uri(string.Format("https://www.google.com/search?q={0}", c));
                client.DownloadStringCompleted += (s, e2) =>
                {
                    callback(c, e2.Result.Length);
                };
                client.DownloadStringAsync(uri);
            };
        };
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int callid = rand++;
            Debug.WriteLine("Executing CallID #{0}", callid);
            DownloadDataInBackground((c3, r3) =>Debug.WriteLine("The result for the callid {0} is {1}", c3, r3))(callid);
        }
    }
