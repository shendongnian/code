    public class Recipe : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int MeatWeightPerPers { get; set; }
        public string ImagePath { get; set; }
        // Instead of array, use ObservableCollection
        public ObservableCollection<RecipeDetails> Details { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Recipe(string name, int meatWeight, string image)
        {
            Name = name;
            MeatWeightPerPers = meatWeight;
            ImagePath = image;
            // Initialize Details collection
            Details = new ObservableCollection<RecipeDetails>();
        }
        public void AddDetails(RecipeDetails details)
        {
            Details.Add(details);
        }
    }
