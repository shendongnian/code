    DropDownList changesList = new DropDownList();
    ListItem item;
    item = new ListItem();
    item.Text = "go to google.com";
    item.Value = "http://www.google.com";
    changesList.Items.Add(item);
    changeList.Attributes.Add("OnChange", "MyFunction();");
