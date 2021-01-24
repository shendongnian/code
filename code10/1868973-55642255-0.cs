        public class CommandButtonViewModel : INotifyPropertyChanged  
        {   
            private string _iconprop;
            public string IconProp
            {
                get
                {
                    return _iconprop;
                }
                set
                {
                    _iconprop = value;
                    NotifyPropertyChanged("IconProp");
                }
            }
       
        private string _placeholderprop;
        public string PlaceHolderProp
        {
            get
            {
                return _placeholderprop;
            }
            set
            {
                _placeholderprop = value;
                NotifyPropertyChanged("PlaceHolderProp");
            }
        }
  
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
