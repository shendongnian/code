    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.webBrowser1.NewWindow2 += webBrowser_NewWindow2;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            webBrowser1.NewWindow2 -= webBrowser_NewWindow2;
            base.OnFormClosing(e);
        }
        void webBrowser_NewWindow2(object sender, WebBrowserNewWindow2EventArgs e)
        {
            var popup = new Form1();
            popup.Show(this);
            e.PpDisp = popup.Browser.ActiveXInstance;
        }
        public WebBrowserNewWindow2 Browser
        {
            get { return webBrowser1; }
        }
    }
