    protected void Page_PreInit(object sender,Event args e) 
    { 
    if(Session["Theme name"] != null)
    {
    this.Theme=Session["Theme name"].ToString(); 
    }
    else
    {
    //use the default theme
    }
} 
