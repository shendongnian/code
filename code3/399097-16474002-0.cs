        private static void SetFileAssociation(string icon, string application, string openArg, string extension , string progId , string description )
        {
            Trace.WriteLine("-----Create File Association-----");
            RegistryKey classesKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true);
            classesKey.CreateSubKey(extension).SetValue(string.Empty, progId);
            RegistryKey progKey = classesKey.CreateSubKey(progId);
            if (description != null)
            {
                progKey.SetValue(string.Empty, description);
            }
            if (icon != null)
            {
                progKey.CreateSubKey("DefaultIcon").SetValue(string.Empty, icon);
            }
            progKey.CreateSubKey(@"Shell\Open\Command").SetValue(string.Empty,
                application + openArg);
            Trace.WriteLine("-----Finish File Association-----");
        }
