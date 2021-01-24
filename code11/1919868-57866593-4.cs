    public class CategoryViewModel
    {
        public ObservableCollection<CategoryModel> Categories { get; set; }
        public CategoryViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>();
        }
    }
