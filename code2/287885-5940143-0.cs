    if(Page.IsNotPostBack)
    {
        DropDownList1.Items.Add(new ListItem("",""));
        for(int i = 0; i <= 100; i++)
            DropDownList1.Items.Add(new ListItem(i.ToString(), i.ToString());
    }
