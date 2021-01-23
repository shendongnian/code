    class CategorySml
    {
      public int CategoryID {get; set;}
      public string CategoryName {get; set;}
    }
...
    NorthwindDataContext db = new NorthwindDataContext();
                List<CategorySml> oList = new List<Category>();
                var result = from p in db.Categories
                             select new CategorySml { CategoryID = p.CategoryID, CategoryName=p.CategoryName };
