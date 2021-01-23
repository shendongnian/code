	if(!IsPostBack) 
	{ 
		//Creating Items 
		ListItem li1 = new ListItem("Male", "1"); 
		ListItem li2 = new ListItem("Female", "2"); 
		ListItem li3 = new ListItem("Secret", "3"); 
		//Adding Items to DropDownList 
		DropDownList1.Items.Add(li1); 
		DropDownList1.Items.Add(li2); 
		DropDownList1.Items.Add(li3); 
	}
