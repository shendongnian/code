     public class Rootobject
    {
        public Property1[] Property1 { get; set; }
    }
    public class Property1
    {
        public string type { get; set; }
        public string version { get; set; }
        public string comment { get; set; }
        public string name { get; set; }
        public string database { get; set; }
        public Datum[] data { get; set; }
    }
    public class Datum
    {
        public string id { get; set; }
        public string word { get; set; }
        public object synonym { get; set; }
        public string definition { get; set; }
    }
