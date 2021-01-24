    public void button1_Click(object sender, EventArgs e) 
    {
        if(ButtonClick != null)
            ButtonClick(this, e);
    }
    
    obj.ButtonClick += (Sender, e) => 
    {
        splitContainer1.Panel2.Visible = false;
    };
