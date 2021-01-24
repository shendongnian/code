    public class Fridge
    {
        public string color { get; set; }
        public string comment { get; set; }
        public int version { get; set; }
        public int date { get; set; }
        public int features { get; set; }
        public string purpose { get; set; }
        public List<int> format { get; set; }
        public List<List<int>> build { get; set; }
    }
    
    public class RootObject
    {
        public string modelName { get; set; }
        public Fridge Fridge { get; set; }
    }
