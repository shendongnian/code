    protected void buttonClick(object sender, EventArgs e)
    {
        string currUser =
            User.Identity.Name.ToString().Trim()
                .Substring(User.Identity.Name.ToString().Trim()
                .IndexOf("\\") + 1);
    
        Inventory.Employee.DB objEmpDB = new Inventory.Employee.DB();
        Inventory.Employee.Details objEmpDetails = 
            new Inventory.Employee.Details();
    
        objEmpDetails = objEmpDB.Get(currUser);
    
        Welcome.Text = 
            "Current User: " + objEmpDetails.Employee_Full_Name;
    
        var objUserDetails = new Inventory.User.Details();
        Inventory.User.DB objUserDB = new Inventory.User.DB();
    
        if (objUserDB.UserAuthenticates(currUser))
        {
            objUserDetails = objUserDB.Get(currUser);
            currUserToken = objUserDetails.User_Token.Value;
    
            userID.Text = currUser;
    
            if (objUserDetails.Active_User_Name != objUserDetails.User_Name)
            {
                lShadow.Text = "Showin: " + objUserDetails.Active_User_Name;
                lServer.Text = "(" +
                objUserDB.UserPermissionName(objUserDetails.Active_Logon_Name)
                    + ") - " + System.Environment.MachineName;
                lShadow.ToolTip = Inventory.Properties.Settings.Default
                    .connectionString.Substring(0, Inventory.Properties
                    .Settings.Default.connectionString.IndexOf(';'));
                divShadow.Visible = true;
            }
            else
                divShadow.Visible = false;
    
            lWelcome.Text = "Current User: " + objUserDetails.User_Name;
        }
    }
