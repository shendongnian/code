    string s = "T";
    string typeName = string.Empty;
    
    // Determine whether s is a letter or digit
    if (Char.IsDigit(s[0]))
    {
        typeName = "Digit" + s;
    }
    else if (Char.IsLetter(s[0]))
    {
        typeName = "Letter" + s;
    }
    
    // Get real type from typeName
    Type type = Type.GetType(typeName);
    
    // Create instance of type, using s as argument
    object instance = Activator.CreateInstance(type, new object[] { s });
