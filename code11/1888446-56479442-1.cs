    public class Feature
    {
        public bool available { get; set; }
        public string status { get; set; }
        public bool admin { get; set; }
    }
    
    public class RootObject
    {
        public int userId { get; set; }
        public string account { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public List<Feature> features { get; set; }
    }
