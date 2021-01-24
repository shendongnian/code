    var filters = new Dictionary<string, object> 
    {
        { "Appearance", "Joyous" },
        { "Colour",     "White" }
    };
    var chosenOnes = snowmen;
    foreach(var filter in filters)
    {
        chosenOnes = chosenOnes.Where(a => 
            a.GetType()
             .GetProperty(filter.Key + "Prop")
             .GetValue(a, null) == filter.Value
        );
    }
