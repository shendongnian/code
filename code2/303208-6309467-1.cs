    public void CheckLogIn()
    {
        if (Sel.IsElementPresent(GetAppConfig("SignOn")))
        {
            Sel.Type(GetAppConfig("UserNameField"), GetAppConfig("UserName"));
            Sel.Type(GetAppConfig("PWDField"), GetAppConfig("PWD"));
            Sel.Click(GetAppConfig("Go"));
        }
        else
        {
            // do nothing
        }
    }
