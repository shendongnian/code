    private bool? canLogin;
    private bool? somethingOk;
    private bool CanLogin
    {
        get
        {
            if (canLogin == null)
                canLogin = Login("johndoe","password");
            return canLogin.Value;
        }
    }
    private bool SomethingOk
    {
        get
        {
            if (somethingOk == null)
                somethingOk = checkForSomething("johndoe");
            return somethingOk .Value;
        }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        if (this.CanLogin && this.SomethingOk && // other checks) 
        {
            DoOpenDashboard();            
        }
    }
