    protected string currentProductID
    {
        get
        {
            return (string)ViewState["ProductID"];
            //or: 
            //return Request.QueryString["ProductID"];
        }
        set
        {
            ViewState.Add("ProductID", value);
            //or something like: 
            //Response.Redirect(ResolveUrl("~/MyPage.aspx?ProductID=" + value));
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //If the problem only occurs when not posting back, wrap the below in
        // an if(!IsPostBack) block. My past issue occurred on both postbacks
        // and page refreshes.
        //Note: I'm assuming Session["ProductID"] should never be null.
        
        if (currentProductID == null)
        {
            //Loading page for the first time.
            currentProductID = (string)Session["ProductID"];
        }
        else if (currentProductID != Session["ProductID"])
        {
            //ProductID has changed since the page was first loaded, so react accordingly. 
            //You can use the original ProductID from the first load, or reset it to match the one in the Session.
            //If you use the earlier one, you may or may not want to reset the one in Session to match.
        }
    }
