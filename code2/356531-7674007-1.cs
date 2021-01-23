    class MyViewModel : INotifyPropertyChanged
      {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
          if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private string _mode;
    
        public string Mode
        {
          get { return _mode; }
          set
          {
            _mode = value;
            OnPropertyChanged("Mode");
    
            // OnPropertyChanged("Something");
            // or build up via a method:
            // Something = DetermineFromMode(Mode);
          }
        }
    
        private string _something;
    
        public string Something
        {
          get { return _something;  }
          set
          {
            _something = value;
            OnPropertyChanged("Something");
          }
        }
      }
