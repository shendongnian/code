    public class SomeClass
    {
        private static readonly object CategoryListLock = new object();
        private readonly List<Category> _categories = new List<Category>();
        private bool _loaded = false;
        public void SetCategories()
        {
            if(!_loaded)
            {
                lock(CategoryListLock)
                {
                    if(!_loaded)
                    {
                        _categories.AddRange(GetCategories());
                        _loaded = true;
                    }
                }
            }
            DoSomethingElse();
        }
        public IList<Category> GetCategories()
        {
            return RetrieveCategories().Select(Something).ToList();
        }
    }
