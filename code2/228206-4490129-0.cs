    DropDownList1.DataValueField = "ID";
    DropDownList1.DataTextField = "Name";
    DropDownList1.DataSource = new[] {
    	new { ID = 1, Name = "Alice" },
    	new { ID = 2, Name = "Mike" },
    	new { ID = 3, Name = "John" }
    };
    DropDownList1.DataBind();
