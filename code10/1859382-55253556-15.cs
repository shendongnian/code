    public class SomeClass : INotifyPropertyChanged
    {
        private string selectedCategory;
        public string SelectedCategory
        {
            get => this.selectedCategory;
            set
            {
                this.selectedCategory = value;
                OnPropertyChanged();
                GetFormNames(this.SelectedCategory);
            }
        }     
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  
       
        ...
    }
