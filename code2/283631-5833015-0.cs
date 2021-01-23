    public class ComputerEntry : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
            private void RaisePropertyChanged(String propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            private String _ComputerName;
            public String ComputerName
            {
                get
                {
                    return _ComputerName;
                }
                set
                {
                    if (_ComputerName != value)
                    {
                        _ComputerName = value;
                        this.RaisePropertyChanged("ComputerName");
                    }
                }
            }
        }
