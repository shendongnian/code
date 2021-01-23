    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }// add this:)
    
        public virtual Category Category { get; set; }
    }
