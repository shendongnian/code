    public partial class Form1 : Form
    {
        WebClient _WebClient;
        bool _UpdateNews;
        public Form1()
        {
            InitializeComponent();
            _WebClient = new WebClient();
            _WebClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(_WebClient_DownloadStringCompleted);
            _UpdateNews = false;
        }
        void _WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (_UpdateNews)
            {
                _UpdateNews = false;
                UpdateNews();
            }
            else if (e.Error != null)
            {
                // Report error 
            }
            else
            {
                MessageBox.Show(e.Result);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_WebClient.IsBusy)
            {
                _WebClient.CancelAsync();
                _UpdateNews = true;
            }
            else
            {
                UpdateNews();
            }
        }
        private void UpdateNews()
        {
            _WebClient.DownloadStringAsync(new Uri("http://stackoverflow.com/questions/7084948/c-concurrent-i-o-operations-exception"));
        }
    }
