    public class Category
    {
        public int CategoryId { get; set; }
          
        public string Name { get; set; }
    
        public virtual Category ParentCategory { get; set; }
    
        public virtual ICollection<Category> ChildCategories { get; set; }
    }
