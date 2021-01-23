    public partial class Form1 : Form
    {
        private Awesomium.Windows.Forms.WebControl browser;
        public Form1()
        {
            InitializeComponent();
            browser = new Awesomium.Windows.Forms.WebControl();
            //delay until control is ready
            browser.Paint += browser_Paint;
            Controls.Add(browser);
            browser.Location = new System.Drawing.Point(1, 12);
            browser.Name = "webControl1";
            browser.Size = new System.Drawing.Size(624, 442);
            browser.Source = new System.Uri("http://www.google.it", System.UriKind.Absolute);
            browser.TabIndex = 0;
        }
        void browser_Paint(object sender, PaintEventArgs e)
        {
            browser.Paint -= browser_Paint;
            System.Collections.Specialized.NameValueCollection myCol =
                new System.Collections.Specialized.NameValueCollection();
            myCol.Add("Referer", "http://www.yahoo.com");
            browser.SetHeaderDefinition("MyHeader", myCol);
            browser.AddHeaderRewriteRule("http://*", "MyHeader");
        }
    }
