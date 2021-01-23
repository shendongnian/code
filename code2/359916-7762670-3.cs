    namespace BusinessLayer
    {
         public class Category
        {
             public string Name { get; set; }
             public List<Link> Links { get; set; }
             public static Category GetAll()
             {
                 return DataLayer.GetAllCategories();
             }
        }  
  
        public class Link
        {
            public string Url { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }    
