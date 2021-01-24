    public class PagedResult<T>
    {
        public int count { get; set; }
        public int pages { get; set; }
        public T[] result { get; set; }
    }
    public class ApplicationUser
    {
        public string id { get; set; }
        public string orgId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public object token { get; set; }
        public string badge { get; set; }
        public string defaultLanguage { get; set; }
        public string supervisorId { get; set; }
        public bool inactive { get; set; }
    }
