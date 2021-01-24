    public event EventHandler Button1Clicked;
    private void Button1_Click(object sender, EventArgs e)
    {
        Button1Clicked?.Invoke(this, e);
    }
