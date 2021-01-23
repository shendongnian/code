    var values = myDbConnection.GetValues();
    var listOfValues = values.Select(x => new ListItem(x.Name, x.Value)).ToList(); // something like that
    listOfValues.Add(new ListItem("All Profiles"));
    
    myCombo.DataSource = listOfValues;
    myCombo.DataBind();
