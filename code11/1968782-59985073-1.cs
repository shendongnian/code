    public class UserViewModel
    {
      public void SubmitLoginData(object loginData)
      {
        this.userService.CheckUserExist(this.Login);
      }
    
      public ICommand SubmitLoginDataCommand = new RelayCommand(SubmitLoginData, (param => true);
      public string Login { get; set; }  
      private UserService userService { get; set; }
    }
