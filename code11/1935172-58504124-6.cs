    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ViewModelItem> Items { get; }
            = new ObservableCollection<ViewModelItem>();
        private ViewModelItem selectedItem;
        public ViewModelItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                // fire PropertyChanged event
                // add call optional additional code here
            }
        }
    }
