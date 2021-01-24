     public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<CategoriesModel> _Categories;
        public ObservableCollection<CategoriesModel> CategoriesList
        {
            get
            {
                return this._Categories;
            }
            set
            {
                if (_Categories != value)
                {
                    this._Categories = value;
                    SetPropertyValue(ref _Categories, value);
                }
            }
        }
        public MainPageViewModel()
        {
            CategoriesList = new ObservableCollection<CategoriesModel>
            {
                new CategoriesModel() { Name = "Data 1", ID = "1" },
                new CategoriesModel() { Name = "Data 2", ID = "2" },
                new CategoriesModel() { Name = "Data 3", ID = "3" },
                new CategoriesModel() { Name = "Data 4", ID = "4" },
                new CategoriesModel() { Name = "Data 5", ID = "5" },
                new CategoriesModel() { Name = "Data 6", ID = "6" },
                new CategoriesModel() { Name = "Data 7", ID = "7" }
            };
        }
    }
    
