    public class Child : INotifyPropertyChanged
    {
        private bool _check;    
        public bool Check
        {
            get
            {
                _check = !_check;
                return _check;
            }
        }
        public Child(bool check)
        {
            _check = check;
        }
        public void Notify(string property)
        {
            OnPropertyChanged(property);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
