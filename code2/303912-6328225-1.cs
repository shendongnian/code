    public class AdminViewModel
    {
        public string Status { get; set; }
        [DisplayName("Status")]
        public IEnumerable<SelectListItem> Statuses
        {
            get
            {
                return ReferenceData.GetStatusType();
            }
        }
    }
