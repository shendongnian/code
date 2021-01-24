    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private bool _isSelected;
    
        public ParentVM ParentRef { get; set; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value == _isSelected) { return; }
                _isSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
                if (ParentRef != null && _isSelected)
                {
                    ParentRef.CurrentlySelected = this;
                }
            }
        }
    
        public int Data { get; }
        public ViewModel(int data) => Data = data;
    }
