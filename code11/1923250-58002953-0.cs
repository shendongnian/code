    public class Rootobject
    {
        public string type { get; set; }
        public Properties Properties { get; set; }
    }
    public class Properties
    {
        public string type { get; set; }
        public Values[] values { get; set; }
    }
    public class Values
    {
        public string type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
