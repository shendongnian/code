    foreach (Control c in this.Page.Header.Controls)
    {
    	HtmlMeta meta = c as HtmlMeta;
        if (meta != null && meta.Name == "Keywords")
        {
            // Do something with meta.
        }
    }
