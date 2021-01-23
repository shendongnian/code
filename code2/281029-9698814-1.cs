    if (!Page.IsPostBack) 
    {    
     if (String.IsNullOrEmpty(Session["UserID"]))
    {
     Session["UserID"] = ""; 
    }
    } 
