    public static partial class ReferenceData
    {
        public static IEnumerable<SelectListItem> GetDatastore()
        {
            return new[]
                {
                    new SelectListItem { Value = "DEV", Text = "Development"  },
                    new SelectListItem { Value = "DC1", Text = "Production" }
                };
        }
