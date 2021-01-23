    // for getting the Id prop
    var identProp = _businessObject.GetType().GetProperty("Id");
    string result = _businessObject.GetType().Name;
    if (identProp != null)
    {
        result += " " + identProp.GetValue(stuff, null).ToString();
    }  
