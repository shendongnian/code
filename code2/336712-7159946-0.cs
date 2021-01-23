    // Create checkboxList
    CheckBoxList chkDynamic = new CheckBoxList();
    // Set attributes for checkboxlist
    chkDynamic.ID = "example";
    chkDynamic.AutoPostBack = true;
    // Create checkbox
    CheckBox chk = new CheckBox();
    // Set attributes for checkbox
    chk .ID = "example";
    
    // Add checkbox to checkboxlist
    chkDynamic.Controls.Add(chk);
    // Add your new control to page
    this.Form.Controls.Add(chkDynamic);
