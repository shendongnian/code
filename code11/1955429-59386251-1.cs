    public class UserViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<User> _UsersList { get; set; }
            private User selecteduser;
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
    
                {
                    PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                    this.PropertyChanged(this, args);
                }
            }
            public UserViewModel()
            {
                ......
                UpdateCommand = new RelayCommand(UpdateCustomer);
            }
            ......
            public RelayCommand UpdateCommand { get; set; }
    
            public void UpdateCustomer()
            {
                Users.Add(
                    new User
                    {
                        FirstName = "ABC",
                        LastName = "XYZ",
                        City = "TEST",
                        Country = "TESTREST",
                        State = "GUJRAT",
                        UserId = 9
    
                    });
            }
    
        }
