    object paramValue = ...;
    double doubleValue;
    if(!double.TryParse(thisNavigator.Value, out doubleValue))
    {
        paramValue = thisNavigator.Value;
    }
    
