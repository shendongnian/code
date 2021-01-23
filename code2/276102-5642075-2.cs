    string myString = null;
    
    // This is valid comparison because myString is a string object.
    // However, the string is not *empty*, it is null, thus it has *no* value.
    if(myString == "")
    {
        DoSomething();
    }
    
    // This is not acceptable, as null.Length has no meaning whatsoever.
    // The expression compiles because the variable is of type string,
    // However, the string is null, so the "Length" property cannot be called.
    if(myString.Length < 5)
    {
        DoSomethingElse();
    }
