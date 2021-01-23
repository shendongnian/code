    string groupName = string.Empty; // or null, if empty is meaningful
    do
    {
        switch (/* ... */)
        {
            case "NAME":
                groupName = thisNavigator.Value;
                break;
            case "HINT":
                // use groupName
