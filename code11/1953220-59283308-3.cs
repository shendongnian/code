    public event EventHandler Test;
    
    private void Button1_Click(object sender, EventArgs e)
    {
         Test?.Invoke(this, EventArgs.Empty);
    }
