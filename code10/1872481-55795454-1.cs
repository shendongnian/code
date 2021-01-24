    foreach (var saaOperator in saaOperators)
    {
        string[] valuesToDisplay;
        for (var x = 0; x < saaOperator.Units.Count; x++)
        {
            if (x == 0) // show all the properties
                valuesToDisplay = new[]
                    {saaOperator.Identifier, 
                     saaOperator.Name, 
                     saaOperator.Profile, 
                     saaOperator.Units[x]};
            else // after the first unit, don't repeat the other properties
                valuesToDisplay = new[]
                    {"", "", "", saaOperator.Units[x]};
        }
    }
