        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mime;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Deployment.WindowsInstaller;
    
    namespace RegistrationInfoCustomAction
    {
        public class CustomActions
        {
            [CustomAction]
            public static ActionResult SaveUserInfo(Session session)
            {
                File.Create(System.IO.Path.Combine(session.CustomActionData["INSTALLFOLDER"], "test.xml"));
    
                return ActionResult.Success;
            }
        }
    }
