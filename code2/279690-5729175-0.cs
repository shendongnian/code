    for (int i = 0; i < table.Rows.Count; i++)
    {
        var firstName = table.Rows[i]["FName"].ToString()
        var employeeId = table.Rows[i]["EmployeeID"].ToString();
        CheckBoxList1.Items.Add(new ListItem { Text = firstName, Value = employeeId });
        CheckBoxList2.Items.Add(new ListItem { Text = firstName, Value = employeeId });
        CheckBoxList3.Items.Add(new ListItem { Text = firstName, Value = employeeId });
        CheckBoxList4.Items.Add(new ListItem { Text = firstName, Value = employeeId });
        CheckBoxList5.Items.Add(new ListItem { Text = firstName, Value = employeeId });
    }
