    public class WordData
    {
        public string id { get; set; }
        public string word { get; set; }
        public object synonym { get; set; }
        public string definition { get; set; }
    }
    public class PropertyData
    {
        public string type { get; set; }
        public string version { get; set; }
        public string comment { get; set; }
        public string name { get; set; }
        public string database { get; set; }
        public List<WordData> data { get; set; }
    }
    public class BaseResponse
    {
        public List<PropertyData> Property1 { get; set; }
    }
    
