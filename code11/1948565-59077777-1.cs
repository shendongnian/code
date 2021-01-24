     public class BaseGrid<T> where T : class
    {
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public List<T> rows { get; set; }
    }
