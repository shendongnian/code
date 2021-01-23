    public partial class MyUserControl : System.Web.UI.UserControl , IUserControl 
    {
        public string TabName
        {
            get { return ViewState["TabName"] == null ? string.Empty : ViewState["TabName"].ToString(); }
            set { ViewState["TabName"]= value; }
        }
        public string TabUrl
        {
            get { return ViewState["TabUrl"] == null ? string.Empty : ViewState["TabUrl"].ToString(); }
            set { ViewState["TabUrl"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    }
