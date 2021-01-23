    public class ExpandableGroupName : INotifyPropertyChanged
    {
        private object _name;
        public object Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private bool? _isExpanded = false;
        public bool? IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public override bool Equals(object obj)
        {
            return object.Equals(obj, _name);
        }
        public override int GetHashCode()
        {
            return _name != null ? _name.GetHashCode() : 0;
        }
        public override string ToString()
        {
            return _name != null ? _name.ToString() : string.Empty;
        }
    }
