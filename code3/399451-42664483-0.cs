    public class Model : INotifyPropertyChanged
    {
        #region INotify Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
        public string _Name;
        public string Name {
            get { return _Name;  }
            set { _Name = value; NotifyPropertyChanged("Name"); }
        }
        public override string ToString()
        {
            return Name;
        }
    }
