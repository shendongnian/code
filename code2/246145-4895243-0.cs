    public class FoodViewModel
    {
        Food _food;
        public FoodViewModel(Food food)
        {
        }
        public bool ShowTabItem
        {
            get
            {
                return _food.Type == FoodType.Vegetable;
            }
        }
    }
