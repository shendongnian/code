    using System.Threading;
    private AuthSession _authSession;
        
    public MainWindowConstructor()
    { 
        Thread loginThread = new Thread(new ThreadStart(Login());
        loginThread.Start();
        //Continue initializing
    }
        
    private void Login()
    {
        LoginWindow loginWindow = new LoginWindow();
        _authSession = loginWindow.GetAuthSession();
        loginWindow.Close();
    }
