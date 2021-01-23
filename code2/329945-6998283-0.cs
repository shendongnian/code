    protected void myMeta(string myTitle, string myContent)
    {
        Page.Title = myTitle;
        if ((Page.Header != null) && (Page.Header.Controls.Count > 0))
        {
            Page.Header.Controls.AddAt(1, new HtmlMeta("content", myContent));
        }
    }
