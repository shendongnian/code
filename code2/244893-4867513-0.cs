    public class SomeClass
    {
        private IList<Category> _categories;
    
        public void SetCategories()
        {
            lock(this) 
            {
              _categories = GetCategories() ?? new List<Category>();
              DoSomethingElse();
            }
        }
    
        public IList<Category> GetCategories()
        {
            return RetrieveCategories().Select(Something).ToList();
        }
    }
