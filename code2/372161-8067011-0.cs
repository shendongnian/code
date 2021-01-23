    public event EventHandler BasePageInitialized;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.BasePageInitialized != null)
            this.BasePageInitialized(this, e);
    }
