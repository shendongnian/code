    class BaseCategory
    {
      public string CategoryName { get; set; }
    }
    class CategorySml : BaseCategory
    
    {
        public int CategoryID { get; set; }
    }
    
    NorthwindDataContext db = new NorthwindDataContext();
            List<BaseCategory> oList = new List<BaseCategory>();
            oList = db.Categories.Select(p => new BaseCategory{ CategoryName = p.CategoryName }).ToList();
