     public class CategoryModel
    {
        public string CategoryName { get; set; }
        public ObservableCollection<ValueModel> values { get; set; }
        public CategoryModel()
        {
            values = new ObservableCollection<ValueModel>();
        }
    }
