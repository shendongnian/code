    public class UserCriteria
    {
        public GridSortOptions GridSortOptions { get; set; } //Enum for ASC and DESC
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? IsActive { get; set; }
        public string UserName { get; set; }
    }
