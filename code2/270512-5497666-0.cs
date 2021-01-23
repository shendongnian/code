    public class MyViewModel
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public IEnumerable<SelectListItem> Years
        {
            get
            {
                return Enumerable.Range(2000, 12).Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = x.ToString()
                });
            }
        }
    }
