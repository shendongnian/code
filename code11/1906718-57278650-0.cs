public void ADLogin()
{
    SearchResult result = null;
    try
    {
        DirectoryEntry root = new DirectoryEntry("LDAP://" + "domain", txtUsername.Value, txtPassword.Value);
        DirectorySearcher searcher = new DirectorySearcher(root, "(sAMAccountName=" + txtUsername.Value + ")");
        result = searcher.FindOne();
    }
    catch (Exception)
    {
    }
    if (result != null && result.Properties["sAMAccountName"] != null)
    {
        //AD Login Success        
        FormsAuthentication.RedirectFromLoginPage(txtUsername.Value, Login1.RememberMeSet);
    }
    else
    {
        //AD Login failed         
        //Display Error Message
    }
}
Not sure why you think it's bad practice the way you had it though. The best practice (without having more context of where this code is) would probably be to do your error logging in the catch block and then re-throw; silent failure is a bad practice.
