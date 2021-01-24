    class MvItems : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void  RaisePropertyChanged(
                [System.Runtime.CompilerServices.CallerMemberName]
                string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private object mvName;
        public object MvName 
        {
            get => return mvName; 
            set
            {
                mvName = value;
                RaisePropertyChanged();
            }
        }
