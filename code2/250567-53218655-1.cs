    var assembly = Assembly.Load("TestCS");
    var converter = new EnumConverter(assembly.GetType("TestCS.TestEnum"));
    var enumValColl = converter.GetStandardValues();
    foreach (var val in enumValColl)
        Debug.WriteLine("{0} = {1}", val, (int)val);
        
