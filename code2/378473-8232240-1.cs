    public class uu: INotifyPropertyChanged
    {
        private bool _ck;
        public bool Ck
        {
            get { return _ck; }
            set
            {
                _ck = value;
                this.NotifyPropertyChanged("Ck");
            }
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
