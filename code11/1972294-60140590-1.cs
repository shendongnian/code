    public class MVVM : INotifyPropertyChanged
    {
        // Set to Private since we NEVER want MVVM binding to this property becuase it DOES NOT 
        // call the 'OnPropertyChanged' whenever the value is changed 
        private bool _isShowFrame= true;  
        public bool IsShowFrame
        {
            get => _isShowFrame;
            set
            {
                // We check to see if the value has changed, if it hasn't we're done. 
                if (_isShowFrame == value) return;
                // If the value HAS changed, we will save the new value here. 
                _isShowFrame = value;
                // We will now let everyone know that the value has changed! This will update your UI!
                OnPropertyChanged(); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
