    public class ViewModel : INotifyPropertyChanged
    {
        private OuterViewModel currentItem;
        public OuterViewModel CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                NotifyPropertyChanged(nameof(CurrentItem));
            }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
