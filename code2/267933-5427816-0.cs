    public class CheckedListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _IsChecked;
        public bool IsChecked 
        { 
            get { return _IsChecked; }
            set 
            {
                _IsChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
