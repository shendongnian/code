    public event EventHandler ButtonClicked;
    protected virtual void OnButtonClicked(EventArgs e)
    {
        var handler = ButtonClicked;
        if (handler != null)
            handler(this, e);
    }
    private void Button_Click(object sender, EventArgs e)
    {        
        OnButtonClicked(e);
    }
