    protected void Button1_Click(object sender, EventArgs e)
    {
        var host = Page as ILabelHost;
        if (host != null)
        {
            host.SetLabel("Hello World");
        }
    }
