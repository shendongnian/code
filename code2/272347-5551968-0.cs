    public class FormsWebBrowser : 
        System.Windows.Forms.Integration.WindowsFormsHost
    {
        System.Windows.Forms.WebBrowser Browser = 
            new System.Windows.Forms.WebBrowser();
        public FormsWebBrowser()
        {
            Child = Browser;
            Browser.DocumentTitleChanged += 
                new EventHandler(Browser_DocumentTitleChanged);
        }
        void Browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.DocumentTitle = Browser.DocumentTitle;
        }
        ///<summary>
        /// This will let you bind
        ///</summary>
        public string DocumentTitle
        {
            get { return (string)GetValue(DocumentTitleProperty); }
            private set { SetValue(DocumentTitleProperty, value); }
        }
        public static readonly DependencyProperty DocumentTitleProperty =
            DependencyProperty.Register("DocumentTitle", typeof(string), 
            typeof(FormsWebBrowser), new FrameworkPropertyMetadata(""));
    }
