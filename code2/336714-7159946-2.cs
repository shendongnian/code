    // Create CheckBoxList
    CheckBoxList list= new CheckBoxList();
    // Set attributes for CheckBoxList
    list.ID = "CheckBoxList1";
    list.AutoPostBack = true;
    // Create ListItem
    ListItem listItem = new ListItem();
    // Set attributes for ListItem
    listItem .ID = "ListItem1";
    
    // Add ListItem to CheckBoxList
    list.Items.Add(listItem );
    // Add your new control to page
    this.Form.Controls.Add(list);
