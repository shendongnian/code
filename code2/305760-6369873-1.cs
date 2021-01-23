    protected void Page_Init(object sender, EventArgs e)
    {
        this.Master.MasteridButton_Click +=new EventHandler(Master_MasteridButton_Click);
    }
    
    protected void Master_MasteridButton_Click(object sender, EventArgs e)
    {
        this.lblMyLable.Text = "My Text";
    }
