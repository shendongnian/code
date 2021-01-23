    private void InitContent()
    {
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            if((Content = GetContent(Convert.ToInt64(Request.QueryString["id"]))) != null)
                ContentMode = ContentFrom.Query;
            else if(DefaultId != null && (Content = GetContent(DefaultId)) != null)
                ContentMode = ContentFrom.Default;
            else
                ContentMode = ContentFrom.None;
    }
