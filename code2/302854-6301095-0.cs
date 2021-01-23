    var dictionary = new Dictionary<int, string>();
    dictionary.Add(1, "Connection1");
    dictionary.Add(2, "Connection2");
    dictionary.Add(3, "Connection3");
    dictionary.Add(4, "Connection4");
    // Binding the dictionary to the DropDownList:
    dropDown.DataTextField = "Value";
    dropDown.DataValueField = "Key";
    dropDown.DataSource = dictionary;  //Dictionary<int, string>
    dropDown.DataBind();
