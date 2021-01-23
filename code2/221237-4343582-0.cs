    private static object gate = new object();
        private static bool initialized = false;
        protected void Application_BeginRequest()
        {
            if (initialized)
            {
                return;
            }
            lock (gate)
            {
                if (!initialized)
                {
                    // We need to check if this is the first launch of the app and pre-create
                    // the admin role and the first user to be admin (still needs to register).
                    if (!Roles.GetAllRoles().Contains("Administrator"))
                    {
                        Roles.CreateRole("Administrator");
                    }
                    if (!Roles.GetUsersInRole("Administrator").Any())
                    {
                        Roles.AddUserToRole(RoleEnvironment.GetConfigurationSettingValue("DefaultAdminRoleUser"), "Administrator");
                    }
                    initialized = true;
                }
            }
        }
