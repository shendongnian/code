    public class MealViewModel
    {
        public string MealDescription { get; set; }
        public string SelectedUnit { get; set; }
        public IEnumerable<SelectListItem> Units { get; set; }
    }
