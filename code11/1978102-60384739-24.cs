    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Deployment.WindowsInstaller;
    using System.Windows.Forms;
    
    namespace CustomAction1
    {
        public class CustomActions
        {
            [CustomAction]
            public static ActionResult CustomAction1(Session session)
            {
    
    #if DEBUG
                System.Diagnostics.Debugger.Launch();
    #endif
    
                MessageBox.Show("hello world");
    
                session.Log("Begin CustomAction1");
    
                return ActionResult.Success;
            }
        }
    }
