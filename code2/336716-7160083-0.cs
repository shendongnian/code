    CheckBoxList cbList = new CheckBoxList();
        
    for (int i = 0; i < 10; i++)
        cbList.Items.Add(new ListItem("Checkbox " + i.ToString(), i.ToString()));
    placeHolder.Controls.Add(cbList);
