    public event EventHandler ButtonClick;
    protected void Button1_Click(object sender, EventArgs e)
    {
        //bubble the event up to the parent
        if (this.ButtonClick!= null)
            this.ButtonClick(this, e);               
    }
