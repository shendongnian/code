    public abstract class BaseFilter
    {
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
        public int RowStart { get; set; }
        public int RowCount { get; set; }
    }
    public class BookFilter : BaseFilter
    {
        public string ISBN { get; set; }
        public int Year { get; set; }
    }
    public class AuthorFilter : BaseFilter
    {
        public string Name { get; set; }
    }
