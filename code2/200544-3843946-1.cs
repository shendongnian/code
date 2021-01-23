    static void DoSomething(dynamic obj)
    {
        foreach (KeyValuePair<string, string> pair in obj.Properties)
        {
            string name = pair.Key;
            string value = pair.Value;
            // do something
        }
    }
