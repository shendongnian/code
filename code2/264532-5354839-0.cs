    class Category
    {
            public int ParentId { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public static void BuildCatStringList(string prefix, Category c, 
                               IEnumerable<Category> categories, List<string> catStrings)
            {
                if (c.ParentId == 0)
                {
                    catStrings.Add(c.CategoryName);
                    prefix = c.CategoryName;
                }
                var children = categories.Where(cats => cats.ParentId == c.CategoryId);
                if (children.Count() == 0)
                {
                    return;
                }
                foreach (Category child in children)
                {
                    catStrings.Add(prefix + "/" + child.CategoryName);
                    BuildCatStringList(prefix + "/" + child.CategoryName, 
                                       child, categories, catStrings);
                }
    }
    static void Main(string[] args)
    {
            List<Category> categories = new List<Category>();
            categories.Add(new Category() { ParentId = 0, 
                CategoryName = "CD-DVD-Video", CategoryId=1 });
            categories.Add(new Category() { ParentId = 1, 
                CategoryName = "DVD", CategoryId = 10 });
            categories.Add(new Category() { ParentId = 1, 
                CategoryName = "Video cassettes", CategoryId= 11 });
            
            categories.Add(new Category() { ParentId = 0, 
                CategoryName = "Computer Hardware", CategoryId= 2 });
            categories.Add(new Category() { ParentId = 2, 
                CategoryName = "CD & DVD", CategoryId = 12 });
            categories.Add(new Category() { ParentId = 2, 
                CategoryName = "CPU Coolers", CategoryId = 13 });
            categories.Add(new Category() { ParentId = 2, 
                CategoryName = "Cases", CategoryId = 14 });
            categories.Add(new Category() { ParentId = 2, 
                CategoryName = "Keyboards", CategoryId = 15 });
            
            List<String> x = new List<string>();
            foreach (Category cat in categories.Where(c => c.ParentId == 0))
            {                
                Category.BuildCatStringList(String.Empty, cat, categories, x);
            }
    }
