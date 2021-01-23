    protected void Page_Load(object sender, EventArgs e)
    {         
        AgeDropDown.Items.Clear();   
        for (int i = 1; i < 101; i++)
        {
            AgeDropDown.Items.Add(new ListItem(i.ToString(),i.ToString()));
        }
    }
