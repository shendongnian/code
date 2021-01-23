    public class YourClass
    {
        public string ID { get; set; }
        public string E1 { get; set; }
        public string E2 { get; set; }
        public string E3 { get; set; }
    }
    public static YourClass[] GetClassArray(IEnumerable<YourClass> objects)
    {
        return objects.OrderBy<YourClass, string>(c => c.E1)
                      .ThenBy<YourClass, string>(c => c.E2)
                      .ThenBy<YourClass, string>(c => c.E3)
                      .ThenBy<YourClass, string>(c => c.ID)
                      .ToArray<YourClass>();
    }
