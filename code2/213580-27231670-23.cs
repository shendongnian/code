    <!-- language: lang-cs -->
    
        public partial class ReportViewerControl : System.Web.Mvc.ViewUserControl
        {
            protected void Page_Init(object sender, EventArgs e)
            {
                // Required for report events to be handled properly.
                Context.Handler = Page;
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    /* ... report setup ... */ 
                    serverReport.Refresh();
                }
            }
        }
