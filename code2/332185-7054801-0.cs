    DateTime dateValue;
    string dateString = "05/01/2009 14:57:32.8";
    if (DateTime.TryParse(dateString, out dateValue))
    {
        // valid date comes here.
        // use dateValue for this
    }
    else
    {
        // valid date comes here
    }
