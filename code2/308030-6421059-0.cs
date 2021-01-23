    public class PageViewModel
    {
        public PageViewModel()
        {
            this.Categories = new List<Category>();
        }
        public IEnumerable<Category> Categories {get;set;}
    }
