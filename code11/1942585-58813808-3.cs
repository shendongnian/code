    public class UserMovements
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;
    }
    public class ViewByDateViewModel
    {
        public ViewByDateViewModel()
        {
            UserMovements = new PagedResult<UserMovements>();
        }
        public PagedResult<UserMovements> UserMovements { get; set; }
        public string[] Date { get; set; }
    }
