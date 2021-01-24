    public class ModelDto
    {
        public string id { get; set; }
        public string text { get; set; }
    }
    public class ResultList<T>
    {
        public List<T> items { get; set; }
        public int total_count { get; set; }
    }
