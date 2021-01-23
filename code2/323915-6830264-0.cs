    public partial class WebUserControl : System.Web.UI.UserControl
    {
    public WebUserControl()
    {
        ShowAll = true;
    }
    public bool ShowAll
    {
        get { return _showAll; }
        set { _showAll = value; }
    }
    private bool _showAll;
      protected void Page_Load(object sender, EventArgs e)
      {
      }
    }
