    public bool isShuffle {
          get {
            return _isShufle;
          }
          set {
            if (_isShufle != value){
             _isShufle = value;
            OnPropertyChanged("isShuffle");
}
          }
        }
    // Create the RaisePropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
