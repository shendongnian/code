    class SwitchModel : INotifyPropertyChanged
    {
        bool isToggle;
        public SwitchModel()
        {
            IsToggled = Page1.keyValuePairs["Create"];
        }
        public bool IsToggled
        {
            set { SetProperty(ref isToggle, value); }
            get { return isToggle; }
        }
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
