    public partial class Form1 : Form
    {
        private MyWebBrowser _webBrowser;
    
        public Form1()
        {
            InitializeComponent();
    
            _webBrowser = new MyWebBrowser();
            _webBrowser.Dock = DockStyle.Fill;
    
            Controls.Add(_webBrowser);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            _webBrowser.DownloadControlFlags = (int)WebBrowserDownloadControlFlags.DOWNLOADONLY;
            _webBrowser.Navigate("http://mysamplewebsite");
        }
    }
