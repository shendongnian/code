            Outlook.Application outlookApp = null;
            // Check whether there is an Outlook process running.
            if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {
                // If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
                outlookApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
            }
            else
            {
                // If not, create a new instance of Outlook and sign in to the default profile.
                outlookApp = new Outlook.Application();
                Outlook.NameSpace nameSpace = outlookApp.GetNamespace("MAPI");
                nameSpace.Logon("", "", Missing.Value, Missing.Value);
                nameSpace = null;
            }
