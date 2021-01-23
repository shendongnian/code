    Assembly assembly = Assembly.LoadFrom("lib.dll");
    Type attributeType = assembly.GetType("Lib.MarkAttribute");
    Type dataType = assembly.GetType("Lib.Data");
    Attribute attribute = Attribute.GetCustomAttribute(dataType, attributeType);
    if( attribute != null )
    {
        string a = (string)attributeType.GetProperty("A").GetValue(attribute, null);
        string b = (string)attributeType.GetProperty("B").GetValue(attribute, null);
        // Do something with A and B
    }
