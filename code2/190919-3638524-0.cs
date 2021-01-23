    public class Category 
    { 
        public virtual int Id { get; set; } 
        public virtual string Name { get; set; } 
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; } 
    } 
