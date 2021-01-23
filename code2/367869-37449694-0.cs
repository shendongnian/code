    public class ObjectBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                OnPropertyChanged(propertyName, true);
            }
    
            protected virtual void OnPropertyChanged(string propertyName, bool makeDirty)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    
                if (makeDirty)
                    _IsDirty = true;
            }
    
    
            bool _IsDirty;
    
            public bool IsDirty
            {
                get { return _IsDirty; }
            }
    
        }
