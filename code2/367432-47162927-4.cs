    public static partial class ReferenceData
    {
        public static IEnumerable<SelectListItem> GetAnswerType()
        {
            return new[]
                {
                    new SelectListItem { Value = "1", Text = "1 answer"  },
                    new SelectListItem { Value = "2", Text = "2 answers" },
                    new SelectListItem { Value = "3", Text = "3 answers" }
                };
        }
    }
