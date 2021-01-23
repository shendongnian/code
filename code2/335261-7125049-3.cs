    protected void ltFilename_DataBinding(object sender, System.EventArgs e)
    {
        Literal lt = (Literal)(sender);
        if (Eval("yourColumn6Field") == DBNull.Value)
        {
            // just show a text filename
            lt.Text = Eval("orderFilename").ToString();
        }
        else
        {
            // produce the link
            lt.Text = string.Format("<a href='{0}'>{1}</a>",
                 ResolveUrl("~/directory/" + Eval("orderFilename").ToString()),
                 Eval("orderFilename").ToString());
        }
    }
