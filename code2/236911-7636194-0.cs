        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigate("google.com");
            webBrowser1.PreviewKeyDown += new PreviewKeyDownEventHandler(webBrowser1_PreviewKeyDown);
        }
        void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                string activeTag = webBrowser1.Document.ActiveElement.TagName.ToLower();
                if (activeTag == "input" || activeTag == "textarea")
                { }
                else
                { }
            }
        }
