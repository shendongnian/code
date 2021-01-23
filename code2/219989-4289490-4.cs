    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private bool hasChanged = false;
        public bool HasChanged
        {
            get
            {
                return this.hasChanged;
            }
            set
            {
                this.hasChanged = value;
                OnPropertyChanged("HasChanged");
            }
        }
    
        //make it protected, so it is accessible from Child classes
        protected void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
