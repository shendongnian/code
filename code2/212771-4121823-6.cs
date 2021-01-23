    protected void Page_Load(object sender, EventArgs e)
    {
        String editor = String.Empty;
        if(!String.IsNullOrEmpty(Session["Editor"].ToString()))
        {
            editor = Session["Editor"].ToString();
            // do Something();
        }
        else
        {
            // do Something();
        }
    }
  
