    public class UserModel
    {
        public string Login { get; set; }
        public long Id { get; set; } 
    } 
    public class User : INotifyPropertyChanged
    {
      public User(UserModel dataModel)
      {
        this.UserModel = dataModel;
      }
      public string Login 
      {
        get => this.UserModel.Login;
        set
        {
          if (Equals(value, this.UserModel.Login)) return;
          this.UserModel.Login = value;
          OnPropertyChanged();
        }
      }
      public string Id 
      {
        get => this.UserModel.Id;
        set
        {
          if (Equals(value, this.UserModel.Id)) return;
          this.UserModel.Id = value;
          OnPropertyChanged();
        }
      }
      private UserModel UserModel { get; set; }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public class ViewModel : INotifyPropertyChanged
    {
      private getUser()
      {
        UserModel = modelData = Api.GetUser();
        this.User = new User(modelData);
      }
      private User user;
      public User User
      {
        get => this.user;
        set
        {
          if (Equals(value, this.user)) return;
          this.user= value;
          OnPropertyChanged();
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
