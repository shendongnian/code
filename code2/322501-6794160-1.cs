        /// <summary>
        /// This is what is bound to the UI
        /// </summary>
        private ObservableCollection<UserDTO> _Users;
        /// <summary>
        /// Collection of Users
        /// </summary>
        public ObservableCollection<UserDTO> Users
        {
            get
            {
                return _Users;
            }
            set
            {
                if (_Users != value)
                {
                    _Users = value;
                    OnPropertyChanged("Users");
                }
            }
        }
        /// <summary>
        /// Asynchronous Callback For Get Users
        /// </summary>
        private void UserAgentGetCompleted(object sender, List<UserDto> users)
        {
            
             //Make sure we are on the UI thread
              this.Dispatcher.BeginInvoke(() => SetUsers(users));
        }
