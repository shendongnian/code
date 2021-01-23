    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.LightSwitch;
    namespace LightSwitchApplication
    {
        public class Authenticate
        {
            public static adminuser GetCurrentUser()
            {
                adminuser userFound = (from useritem in 
                Application.Current.CreateDataWorkspace().basecampcoreData.adminusers
                where useritem.LoginID == Application.Current.User.Name
                select useritem).SingleOrDefault();
                if (userFound != null)
                    return userFound;
                else
                    return null;
            }
        }
    }
