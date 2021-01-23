    public class ReferenceData
    {
        public string SelectRuleId { get; set; }
        public IEnumerable<SelectListItem> StatusType
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "0", Text = "Release" },
                    new SelectListItem { Value = "1", Text = "Beta" },
                    new SelectListItem { Value = "2", Text = "Alpha" },
                };
            }
        }
    }
