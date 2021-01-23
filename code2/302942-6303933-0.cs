    public class BindWrapper<T> : INotifyPropertyChanged
    {
        private T _Content;
        public T Content
        {
            get
            {
                return _Content; 
            }
            set
            {
                _Content = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Content"));
            }
        }
    
    
        #region INotifyPropertyChanged Members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        #endregion
    }
