			var list = new ListItemCollection {new ListItem("1", "1"), new ListItem("2", "2"), new ListItem("3", "3")};
			DropDownList1.DataSource = list;
			DropDownList1.DataBind();
			DropDownList2.DataSource = list;
			DropDownList2.DataBind();
			DropDownList3.DataSource = list;
			DropDownList3.DataBind();
			var item = DropDownList3.Items.FindByValue("3");
			item.Selected = true;
