    dynamic sampleObject = new ExpandoObject();
    sampleObject.TestProperty = "Dynamic Property"; // Setting dynamic property.
    Console.WriteLine(sampleObject.TestProperty );
    Console.WriteLine(sampleObject.TestProperty .GetType());
    // This code example produces the following output:
    // Dynamic Property
    // System.String
    dynamic test = new ExpandoObject();
    ((IDictionary<string, object>)test).Add("DynamicProperty", 5);
    Console.WriteLine(test.DynamicProperty);
