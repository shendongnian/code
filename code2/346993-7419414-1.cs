    public event EventHandler ButtonClick;
    protected void UserControlButton_Click(object sender, EventArgs e)
    {
        if (ButtonClick != null)
            ButtonClick(sender, e);
    }
