    public class MainController : IDisposable {
    //all forms we are controlling
    LoginForm _loginForm = null;
    //all public members
    public string loginID = null;
    #region Singleton Instance stuff
    private static MainController me = null;
    private void MainController() { }
    public static Instance {
        get {
            if(me == null) {
                me = new MainController();
            }
            return me;
        }
    }
    #endregion
    //all public methods
    public void Init(someargshere) {
        //TODO some init like load config files, etc.
    }
    public void Dispose() {
        //TODO cleanup
    }
    public void ClearSession() {
        loginID = "";
    }
    public void ShowLoginForm() {
        if(loginForm!=null) {
            loginForm.Dispose();
            loginForm == null;
        }
        loginForm = new LoginForm();
        loginForm.Show();
        loginForm.BringToFront();
    }
    //etc
    }
