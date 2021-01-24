    public class YourMainObject
    {
        public Pagination Pagination { get; set; }
        public Datum[] Data { get; set; }
    }
    
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfPages { get; set; }
        public int totalCount { get; set; }
    }
    
    public class Datum
    {
        public string SalesOrderNumber { get; set; }
    }
