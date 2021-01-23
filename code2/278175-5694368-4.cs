    YourDomainContext dc = new YourDomainContext();
    LoadOperation loGetUsers = dc.Load(dc.GetUsersQuery());
    loGetUsers.Completed += new EventHandler( loadOperation_Completed );// You will see there is a callback overloads as well
    and then add this as well.
    
    private void loadOperation_Completed( object sender, EventArgs e )
    {
        LoadOperation<User> lo = (LoadOperation<User>)sender;
        //Have a look at all the properties like lo.Error etc. but to see the retrieved users you can either use:
        var users = lo.AllEntities;
        //or if you declared your domaincontext as a class level parameter:
        var users = dc.User;
        foreach (Web.User user in users)
        {
            MessageBox.show(user.username);
        }
    }
