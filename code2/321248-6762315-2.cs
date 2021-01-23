    private void InitSection()
    {
        Control c;
        if( isAdministrator )
            c = Page.LoadControl("~\Administrator.ascx")
        else if( isProvider )
            c = Page.LoadControl("~\Provider.ascx") 
        else
            c = Page.LoadControl("~\User.ascx");
        MyPlaceholder.Controlls.Add(c);
    }
