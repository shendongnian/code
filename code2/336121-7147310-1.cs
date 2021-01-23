    / get value of property: public double Number
    double value = (double)numberPropertyInfo.GetValue(calcInstance, null);
    
    [C#]
    // set value of property: public double Number
    numberPropertyInfo.SetValue(calcInstance, 10.0, null);
