    // initial "false" condition just to start "OR" clause with
    var predicate = PredicateBuilder.False<YourDataClass>();
    if (condition1)
    {
        predicate = predicate.Or(d => d.SomeStringProperty == "Tom");
    }
    if (condition2)
    {
        predicate = predicate.Or(d => d.SomeStringProperty == "Alex");
    }
    if (condition3)
    {
        predicate = predicate.And(d => d.SomeIntProperty >= 4);
    }
    return originalCollection.Where<YourDataClass>(predicate.Compile());
