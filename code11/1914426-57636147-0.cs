    public class Data
    {
        public int Id { get; set; }
        public string story_code { get; set; }
        public string master_code { get; set; }
    }
    
    public class DataList
    {
        public List<Data>  StoriesMasters { get; set; }
    }
