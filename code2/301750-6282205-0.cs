    // Add check items to the control's dropdown.
    string[] itemValues = new string[] { 
        "Circle", "Rectangle", "Ellipse", 
        "Triangle", "Square" };
    foreach (string value in itemValues)
        checkedComboBoxEdit1.Properties.Items.Add(value, CheckState.Unchecked, true);
    // Specify the separator character.
    checkedComboBoxEdit1.Properties.SeparatorChar = ';';
    // Set the edit value.
    checkedComboBoxEdit1.SetEditValue("Circle; Ellipse");
    // Disable the Circle item.
    checkedComboBoxEdit1.Properties.Items["Circle"].Enabled = false;
