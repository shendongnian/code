    public static class ReferenceData
    {
        public static IEnumerable<SelectListItem> GetStatusType()
        {
            return new[]
            {
                new SelectListItem { Value = "0", Text = "Release" },
                new SelectListItem { Value = "1", Text = "Beta" },
                new SelectListItem { Value = "2", Text = "Alpha" },
            };
        }
    }
