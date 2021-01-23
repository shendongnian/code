    class DataContainer
    {
        public string[] Data { get; set; }
    }
    static void Main(string[] args)
    {
         DataContainer dc = new DataContainer();
         dc.Data = new string[] { "hello", "world", "C#" };
         PropertyInfo property = dc.GetType().GetProperty("Data", BindingFlags.Instance | BindingFlags.Public);
         MethodInfo accessor = property.GetGetMethod(); //this will fail if you make the property { set; } only
         string[] propertyValue = accessor.Invoke(dc, null) as string[];    
         Console.Read();
    }
