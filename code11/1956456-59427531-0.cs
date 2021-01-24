    public class UsersViewModel
    {
      public ObservableCollection<UsersModel> Users { get; set; }
      private UsersModel selectedUser;
      public UsersModel SelectedUser
      {
        get => this.selectedUser; 
        set => this.selectedUser = value;
      }
      public UsersViewModel()
      {
        // fetch data from db.            
        DataAccess da = new DataAccess();
        Users = new ObservableCollection<UsersModel>(da.GetRegisteredUsers());
      }
    }
