      public abstract class ViewModel : INotifyPropertyChanged
      {
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string propertyName)
        {
          if (PropertyChanged != null)
          {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
        }
      }
    
        
      public class MyViewModel : ViewModel
      {
        public ObservableCollection<Item> Items
        {
          get
          {
            return new ObservableCollection<Item>()
                     {
                       new Item() {DisplayValue = "Item1", IsSelected = false},
                       new Item() {DisplayValue = "Item2", IsSelected = true},
                       new Item() {DisplayValue = "Item3", IsSelected = false}
                     };
          }
        }
      }
    
      public class Item : ViewModel
      {
        public string DisplayValue { get; set; }
    
        private bool _isSelected = false;
        public bool IsSelected
        {
          get
          {
            return _isSelected;
          }
          set
          {
            _isSelected = value;
            OnPropertyChanged("IsSelected");
          }
        }
      }
