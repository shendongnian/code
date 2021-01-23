    protected void Page_Load(object sender, EventArgs e)
    {
        Void_Button.Attributes.Add("onclick", "var agree=confirm('Confirm to void?'); if (agree){document.getElementById('Void2_Button').click();}");
    }
    
    protected void Void2_Button_Click(object sender, EventArgs e)
    {
        // do something    
    }
    
    protected void Void_Button_Click(object sender, EventArgs e)
    {
    
    }
