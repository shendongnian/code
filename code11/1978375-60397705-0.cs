    Users(.aspx.cs) : System.Web.UI.Page, IUsersView
     {
       IUserPresenter _userPresenter;
    
       public readonly IUsersView _userView;
       public readonly IUser _user;
    
       public User(IUser user,
                IUserPresenter userPresenter)
        {
            _User = user;
            _userPresenter= userPresenter;
    
        }
    
       protected void Page_Load(object sender, EventArgs e)
        {
          try{
               obj = new UserPresenter(this, _projectUpload); //Old Code 
               obj.CheckLoginUserExist(usrLoginID, usrName); //Old Code 
               _userPresenter.CheckLoginUserExist(usrLoginID, usrName); // New Code with DI
            }
        }
     }
