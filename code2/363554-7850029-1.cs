    if (panel != null)
    {
        IList listOfValues = new ComparableListOfObjects();
        var childControls = panel.GetChildren<Control>(x => x.Visibility == Visibility.Visible);
        foreach (Control childControl in childControls)
        {
        if(childControl is TextBox) { listOfValues.Add((childControl as TextBox).Text);     continue; }
        if(childControl is ComboBox) { listOfValues.Add((childControl as ComboBox).SelectedValue); continue; }
        ... 
        }
    }
