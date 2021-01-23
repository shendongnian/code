    void Application_Start(object sender, EventArgs e) 
    {
        Roles.ApplicationName = "MyAppName";
        if (!Roles.RoleExists("admin"))
            Roles.CreateRole("admin");
        if (!Roles.RoleExists("operator"))
            Roles.CreateRole("operator");
        if (!Roles.RoleExists("user"))
            Roles.CreateRole("user");
    }
