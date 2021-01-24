    public class SomeClass : INotifyPropertyChanged
    {
        private string selectedCategory;
        public string SelectedCategory
        {
            get => this.selectedCategory;
            set
            {
                this.selectedCategory = value;
                OnPropertyChanged(nameof(this.SelectedCategory));
                GetFormNames(this.SelectedCategory);
            }
        }        
        ...
    }
