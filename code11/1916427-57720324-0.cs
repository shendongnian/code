    public event EventHandler UserControlButtonClick;
    
    protected void Btn1_Click(object sender, EventArgs e) =>     
        if (this.UserControlButtonClick != null)
            this.UserControlButtonClick(this, e);
