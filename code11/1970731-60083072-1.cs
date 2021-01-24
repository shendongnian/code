    public class UserViewModel : INotifyPropertyChanged
    {
        private UserService userService = new UserService();
        private string _firstName;
        public string Login { get; set; }
        public void SubmitLoginData(object loginData)
        {
            userService.CheckUserExist(Login);
        }
        public ICommand SubmitLoginDataCommand => new RelayCommand(SubmitLoginData, param => true);
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
