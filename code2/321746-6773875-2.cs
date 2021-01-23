    class Test
    {
        public string Name { get; set; }
    }
    Test instance = new Test();
    Type type = typeof(Test);
    Dictionary<string, object> properties = new Dictionary<string, object>();
    foreach (PropertyInfo prop in type.GetProperties())
        properties.Add(prop.Name, prop.GetValue(instance));
