    public class CategoryRepository : ICategoryRepository
    {
        private readonly ModelContext context;
        // Here we pass in the context so that it can be used by methods.
        public CategoryRepository(ModelContext context)
        {
            this.context = context;
        }
        #region ICategoryRepository Members
        public void Add(Category category, Category parent = null)
        {
            if (parent == null)
            {
                parent = this.GetRoot();
            }
            // Snipped the stuff here.
            // Finally add to the current context.
            this.context.ContentCategories.Add(category);
        }
        
        // And all other methods...
    }
