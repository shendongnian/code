    public class SomeEntity : INotifyPropertyChanged {
        private bool _isChecked;
        public bool isChecked
        {
            get { return _isChecked; }
            set
            {
                if (value == _isChecked)
                    return;
                _isChecked= value;
                this.NotifyPropertyChanged("isChecked");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
