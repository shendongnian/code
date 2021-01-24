     public sealed class TestModel: INotifyPropertyChanged
    {
       
     //*******************************************
        string _userDisplayName;
        public string UserDisplayName {
            set { SetProperty(ref _userDisplayName, value); }
            get { return _userDisplayName; }
        }
        public async void LoadAsync()
        {
            try
            {
                UserDisplayName = "updated value: Angela";
                Strings.UserDisplayName = UserDisplayName;
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error while retrieving user name: {exception}");
            }
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
    }
