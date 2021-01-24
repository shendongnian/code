        public class DishesVM
        {
            [Required]
            public string DishName { get; set; }
            [Required]
            public int DishTypeID { get; set; }
            public List<DishTypes> DishTypes { get; set; }
        }
