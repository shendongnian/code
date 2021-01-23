    public event EventHandler Login;
    public event EventHandler Cancel;
    private void OnLogin()
    {
        if (Login != null)
            Login(this, EventArgs.Empty);
    }
    private void OnCancel()
    {
        if (Login != null)
            Login(this, EventArgs.Empty);
    }
    private void btnLogin_Click(object sender, EventArgs e)
    {
        this.OnLogin();
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.OnCancel();
    }
