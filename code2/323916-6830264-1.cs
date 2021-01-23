    public partial class WebUserControl : System.Web.UI.UserControl
    {
      public WebUserControl()
      {
        ShowAll = true;
      }
      private bool _showAll;
      public bool ShowAll
      {
        get { return _showAll; }
        set { _showAll = value; }
      }   
      protected void Page_Load(object sender, EventArgs e)
      {
      }
    }
