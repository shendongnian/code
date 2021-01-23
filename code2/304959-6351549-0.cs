    public class Category
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
    
        public string Name { get; set; }
    
        public virtual Category ParentCategory { get; set; }
        public virtual IList<Category> ChildCategories { get; set; }
    }
