    public class CustomDialog : INotifyPropertyChanged
    {
        //Your implementation of class goes here
    
        public void Initialize(string message)
        {
            Name = message;
            Visibility = Visibility.Visible;
        }
    
        public string Name
        {
            get {return _name;}
            set
            {
                if (_name != value)
                {
                    _name = value;
                    raiseOnPropertyChanged("Name");
                }
            }
        }
    
        //Your implementation of class goes here
    }
