    public class SomeClass : INotifyPropertyChanged
    {
        public SomeClass() {}
        
        private string selectedItem;
        public string SelectedItem
        {
            get => this.selectedItem;
            set
            {
                this.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                GetFormNames(this.SelectedItem);
            }
        }        
        ...
    }
