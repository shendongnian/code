    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Yeah(object sender, CommandEventArgs e)
    {
        string Some = Something.Value;
        this.Result.InnerHtml = Some;
    }
