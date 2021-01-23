    protected void Button1_Click(object sender, EventArgs e)
    {
        var page = Page as _Default;
        if (page != null)
        {
            page.Label1.Text = "Hello World";
        }
    }
