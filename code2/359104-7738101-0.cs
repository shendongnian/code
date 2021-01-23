    //assuming parent is the containing node
    //Parse your 'valuelist'
    var newList = new List<double>();
    foreach (string s in parent.XElement("values").value.Split(" ")) //should check for nulls here
    {
        double value = 0.0;
        if (double.TryParse(s, value))
        {
            newList.Add(value);
        }
        else
        {
            \\throw some format exception
        }
    }
    //Parse your 'mixeduniontype'
    Type valueType = typeof string;
    double doubleValue;
    int intValue;
    boolean booleanValue;
    var stringValue = parent.XElement("value").First();
    if (double.TryParse(stringValue, doubleValue))
    {
        valueType = typeof double;
    }
    else
    {
        if (int.TryParse(stringValue, intValue))
        {
            valueType = typeof int;
        }
        else
        {
            if (bool.TryParse(stringValue, booleanValue))
                 valueType = typeof boolean;
        }
    }
    
