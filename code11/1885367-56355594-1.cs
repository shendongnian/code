    public class Dish
    {
        public int DishId { get; set; }
        public virtual ICollection<DishCategoryMapping> DishCategoryMappings { get; set; }
        //other properties
    }
