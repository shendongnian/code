        public class ReferenceData
        {
            private static readonly SelectListItem[] Items = new[]
                    {
                        new SelectListItem { Value = "0", Text = "Release" },
                        new SelectListItem { Value = "1", Text = "Beta" },
                        new SelectListItem { Value = "2", Text = "Alpha" },
                    };
            [DisplayName("Status")]
            public IEnumerable<SelectListItem> StatusType
            {
                get { return Items; }
            }
        }
