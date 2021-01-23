    public bool MyPostBack
    {
       get
       {
            if (Session["MyPostBack"] == null)
                Session["MyPostBack"] = Page.IsPostBack;
    
            return (bool)Session["MyPostBack"];
       }
       set
       {
            Session["MyPostBack"] = value;
       }
    }
