    public class MyViewModel : BaseViewModel
    {
        public ObservableCollection<obj> ObList1 { get; set; }
        public ObservableCollection<obj> ObList2 { get; set; }
        public ObservableCollection<obj> ObList3 { get; set; }
        private obj _selectedItem1 = new obj();
        public obj SelectedItem1 
        {
            get { return _selectedItem1; }
            //this is the line solved the problem
            //but still not understood thoroughly
            set { SetProperty(ref _selectedItem1, value); }
        }
        //same for _selectedItem2 _selectedItem3
    }
ps: BaseViewModel codes here (not changed, from template codes)
 public class BaseViewModel : INotifyPropertyChanged
    {
        //some other attributes
        //...
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
It seems that by calling SetProperty, OnPropertyChanged will also be revoked.
But still a little bit confusing about why the previous codes go like kind of "one-way" binding.
