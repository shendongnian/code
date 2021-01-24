    public class UtilitiesModel : NotifyBase
    {
        private bool _IsChecked = false;
    
        ...
        // Key 
        // Tag 
        ...
    
        public bool IsChecked 
        { 
          get {return _IsChecked;} 
          set
            {
              _IsChecked = value;
              OnPropertyChanged("IsChecked");
             }
         }
    }
