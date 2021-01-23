    private void InitContent()
    {
        Int64? id = !String.IsNullOrEmpty(Request.QueryString["id"])
                    ? Convert.ToInt64(Request.QueryString["id"])
                    : null;
        if (id != null && (Content = GetContent(id)) != null)
            ContentMode = ContentFrom.Query;
        else if(DefaultId != null && (Content = GetContent(DefaultId)) != null)
            ContentMode = ContentFrom.Default;
        else
            ContentMode = ContentFrom.None;
    }
