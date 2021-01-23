    public void GetClassFields(Type t)
    {
        List<string> fieldNames = new List<string>(t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Select(x => x.Name));
        foreach (string name in fieldNames)
        {
            Console.WriteLine(name);
        }       
    }
    //Usage
    GetClassFields(typeof(ExampleClass));
