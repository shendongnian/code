    public class attributes
    {
        public string name { get; set; }
        public int[] data { get; set; }
        public int[] dataName { get; set; }
        public string[] dataValue { get; set; }
        public string toClick { get; set; }
    }
    public class DataJsonAttributeContainer
    {
        public List<attributes> attributes { get; set; }
    }
