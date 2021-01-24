    public class ViewByDateViewModel
    {
        private DateTime? endDateFilter;
        public ViewByDateViewModel()
        {
            UserMovements = new PagedResult<UserMovements>();
        }
        public PagedResult<UserMovements> UserMovements { get; set; }
        //public string[] Date { get; set; }
        public DateTime? StartDateFilter { get; set; }
        public DateTime? EndDateFilter
        {
            get => endDateFilter;
            set
            {
                if (value != null)
                {
                    endDateFilter = value;
                    endDateFilter = endDateFilter.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                }
            }
        }
    }
