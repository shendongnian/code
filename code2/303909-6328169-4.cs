        public class ReferenceData
        {
            private static readonly ReferenceData _instance = new ReferenceData();
            private ReferenceData()
            {
            }
            public ReferenceData Instance { get { return _instance; } }
            [DisplayName("Status")]
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
