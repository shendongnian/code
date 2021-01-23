    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Windows.Input;
    using Test.Model;
    using System.ComponentModel;
    
    namespace Test.ViewModel
    {
        class UserViewModel : ViewModelBase
        {
            //Private variables
        private ObservableCollection<User> _users;
        RelayCommand _userSave;
        private User _selectedUser = new User();
        //Properties
        public ObservableCollection<User> User
        {
            get
            {
                if (_users == null)
                {
                    _users = new ObservableCollection<User>();
                    _users.CollectionChanged += (s, e) =>
                    {
                        if (e.Action == NotifyCollectionChangedAction.Add)
                        {
                            // handle property changing
                            foreach (User item in e.NewItems)
                            {
                                ((INotifyPropertyChanged)item).PropertyChanged += (s1, e1) =>
                                    {
                                        OnPropertyChanged("EnableListBox");
                                    };
                            }
                        }
                    };
                    //Populate with users
                    _users.Add(new User {UserName = "Bob", Firstname="Bob", Surname="Smith"});
                    _users.Add(new User {UserName = "Smob", Firstname="John", Surname="Davy"});
                }
                return _users;
            }
        }
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; }
        }
        public bool EnableListBox
        {
            get { return !_selectedUser.IsDirty; }
        }
        //Commands
        public ICommand UserSave
        {
            get
            {
                if (_userSave == null)
                {
                    _userSave = new RelayCommand(param => this.UserSaveExecute(), param => this.UserSaveCanExecute);
                }
                return _userSave;
            }
        }
        void UserSaveExecute()
        {
            //Here I will call my DataAccess to actually save the data
            //Save code...
            _selectedUser.SetToClean();
            OnPropertyChanged("EnableListBox");
        }
        bool UserSaveCanExecute
        {
            get
            {
                return _selectedUser.IsDirty;
            }
        }
        //constructor
        public UserViewModel()
        {
            
        }
    }
