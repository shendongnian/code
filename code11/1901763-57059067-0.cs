    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool popupIsVisible;
        public bool PopupIsVisible
        {
            get
            {
                return popupIsVisible;
            }
            set
            {
                popupIsVisible = value;
                OnPropertyChanged("PopupIsVisible");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
