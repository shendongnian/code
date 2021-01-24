    public class UserMovementsViewModel
    {
        public UserMovementsViewModel()
        {
            UserMovementsResults = new PagedResult<UserMovementsResult>();
        }
        public string Query { get; set; } = string.Empty;
        public PagedResult<UserMovementsResult> UserMovementsResults { get; set; } = null;
        public DateTime? StartDateFilter { get; set; }
        public DateTime? EndDateFilter { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
	}
