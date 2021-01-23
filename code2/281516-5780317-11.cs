    class MyCategory
    {
        // add fields for respective Category properties
        // or just the following
        Category category;
        List<Category> subCategories;
        MyCategory (Category category)
        {
            this.category = category;
            
            if (this.category.GotChildren)
            {
                // query TempIDs, Level, etc. from collection of Categories
                // and assign to subCategories collection
            }
        }
        // add property getters/setters as needed
        public List<Category> SubCategories
        { get { return subCategories; } }
    }
