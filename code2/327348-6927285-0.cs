    static void CreateLogin
        (string sqlLoginName,string sqlLoginPassword,string databaseName)
    {
    myServer=GetServer()
    Login newLogin = myServer.Logins[sqlLogin];
    if (newLogin != null)
        newLogin.Drop();
    newLogin = new Login(myServer, sqlLogin);
    newLogin.PasswordPolicyEnforced = false;
    newLogin.LoginType = LoginType.SqlLogin;
    newLogin.Create(sqlLoginPassword);
    //Create DatabaseUser
    DatabaseMapping mapping = 
        new DatabaseMapping(newLogin.Name, MainDbName, newLogin.Name);
    Database currentDb = myServer.Databases[databaseName];
    User dbUser = new User(currentDb, newLogin.Name);
    dbUser.Login = sqlLogin;
    dbUser.Create();
    dbUser.AddToRole("db_owner");
    }
