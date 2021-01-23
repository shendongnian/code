    public class Config
    {
        public Config()
        {
            Test1 = new List<string>() { "A", "B" }; 
            Test2 = new String[] { "A", "B" };
        }
        [XmlIgnore]
        public List<string> Test1 { get; set; }
        public string[] Test2 { get; set; }
        // This member is only to be used during XML serialization
        public string[] Test1_Array 
        { 
            get
            {
                return Test1.ToArray();
            }
            set 
            {
                Test1 = value.ToList();
            }
        }        
        
    }
