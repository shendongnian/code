    public partial class TwitterBrowser : Form
    {
        public TwitterBrowser()
        {
            InitializeComponent();
            webBrowser1.Navigated += OnNavigate;
        }
        private void OnNavigate(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.ToString() != @"https://api.twitter.com/oauth/authorize")
                return;
            if (webBrowser1.Document != null)
            {
                var regex = new Regex("<code>([0-9]*)</code>", RegexOptions.Multiline);
                VerificationCode = regex.Match(webBrowser1.DocumentText).Groups[1].Value;
                Close();
            }
        }
        public string VerificationCode { get; private set; }
        #region Implementation of ITwitterUserInteraction
        public void NavigateTo(Uri uri)
        {
            webBrowser1.Navigate(uri);
        }
        #endregion
    }
