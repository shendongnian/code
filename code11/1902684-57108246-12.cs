    class ChatPageViewModel : INotifyPropertyChanged
    {    
      public ChatPageViewModel()
      {
        this.Users = new ObservableCollection<UserViewModel>();
      }
      private void OnSelectedUserChanged(UserViewModel selectedUser)
      {
        // TODO::Handle selected user
      }
      private bool CanInitializePage(object commandParameter)
      {
        return true;
      }
    
      private void InitializePage(object commandParameter)
      {
        this.Users = new ObservableCollection<UserViewModel>(userManager.GetAllUsers());
      }
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    
      public ICommand InitializePageCommand => new RelayCommand(InitializePage, CanInitializePage);
    
      private UserViewModel selectedUser;
      public UserViewModel SelectedUser 
      {
        get => this.selectedUser;
        set
        {
          this.selectedUser = value;
          OnSelectedUserChanged();
          OnPropertyChanged();
        }
      }
    
      private ObservableCollection<UserViewModel> users;
      public ObservableCollection<UserViewModel> Users 
      {
        get => this.users;
        set
        {
          this.users = value;
          OnPropertyChanged();
        }
      }
    
      private UserManager userManager { get; } = new UserManager();
    }
