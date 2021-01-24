    public class UserViewModel : User, INotifyPropertyChanged
    {
    
        private ObservableCollection<User> _usersList;
        private User _userdetails;
        private User _selecteduser;
        private string _countrySelectItem;
        public ObservableCollection<string> CountryList { get; set; }
        public User Userdetails
        {
            get
            {
                return _userdetails;
            }
            set
            {
                _userdetails = value;
                OnPropertyChanged("Userdetails");
            }
        }
       
        public string CountrySelectItem
        {
            get
            {
                return _countrySelectItem;
            }
            set
            {
                _countrySelectItem = value;
                _userdetails.Country = _countrySelectItem;
                OnPropertyChanged("CountrySelectItem");
            }
        }
    
        public User SelectedUser
        {
            get
            {
                return _selecteduser;
            }
            set
            {
                _selecteduser = value;
              
               if( CountryList.Any(p => p == _selecteduser.Country))
                {
                    CountrySelectItem = _selecteduser.Country;
                }else
                {
                    CountrySelectItem = null;
                }
    
                OnPropertyChanged("SelectedUser");
            }
        }
    
        public ObservableCollection<User> Users
        {
            get
            { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged("Users");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)//string propertyName
        {
            if (PropertyChanged != null)
    
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
    
        public UserViewModel()
        {
            _usersList = new ObservableCollection<User>
            {
                new User{UserId=1,FirstName="Raj",LastName="Beniwal",City="Delhi",State="DEL",Country="INDIA"},
                new User{UserId=2,FirstName="Mark",LastName="henry",City="New York", State="NY", Country="USA"},
                new User{UserId=3,FirstName="Mahesh",LastName="Chand",City="Philadelphia", State="PHL", Country="USA"},
                new User{UserId=4,FirstName="Vikash",LastName="Nanda",City="Noida", State="UP", Country="CANADA"},
                new User{UserId=5,FirstName="Harsh",LastName="Kumar",City="Ghaziabad", State="UP", Country="INDIA"},
                new User{UserId=6,FirstName="Reetesh",LastName="Tomar",City="Mumbai", State="MP", Country="INDIA"},
                new User{UserId=7,FirstName="Deven",LastName="Verma",City="Palwal", State="HP", Country="ENGLAND"},
                new User{UserId=8,FirstName="Ravi",LastName="Taneja",City="Delhi", State="DEL", Country="INDIA"},
                 new User{UserId=9,FirstName="Nico",LastName="Ming",City="WuXi", State="DEL", Country="China"}
            };
            CountryList = new ObservableCollection<string>()
            {
                "INDIA",
                "CANADA",
                "USA",
                "ENGLAND",
                "New Zealand"
            };
    
            try
            {
                _userdetails = new User();
    
            }
            catch
            {
            }
    
            UpdateCommand = new RelayCommand<User>(AddUserMethod);
        }
        public RelayCommand<User> UpdateCommand { get; set; }
    
        public void AddUserMethod(User parameter)
        {
            try
            {
                _usersList.Add(
                new User
                {
    
                    FirstName = _userdetails.FirstName,
                    LastName = _userdetails.LastName,
                    City = _userdetails.City,
                    Country = _userdetails.Country,
                    State = _userdetails.State,
                    UserId = _userdetails.UserId
    
                });
            }
            catch
            {
    
            }
        }
    }
