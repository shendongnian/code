     /// <summary>Makes the association.</summary>
        /// <param name="extension">The extension to associate.</param>
        /// <param name="progID">The program identifier.</param>
        /// <param name="description">The description.</param>
        /// <param name="icon">The full path to the icon.</param>
        /// <param name="application">The full path to the executable.</param>
        /// <param name="exe">The executable.</param>
        public static void MakeAssociation(string extension,
               string progID, string description, string icon, string application, string exe)
        {
            using (var User_Classes = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", true))
            using (var CurrentVersion = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\", true))
            using (var User_Explorer = CurrentVersion.CreateSubKey("Explorer\\FileExts\\." + extension))
            {
                // Register the application
                using (var UserClassesApplications = CurrentVersion.CreateSubKey("App Paths"))
                {
                    UserClassesApplications.CreateSubKey(exe).SetValue("", application);
                }
                // Create ProgID
                if (!string.IsNullOrEmpty(progID))
                {
                    using (var progId_key = User_Classes.CreateSubKey(progID))
                    {
                        progId_key.SetValue("", description);
                        using (var command = progId_key.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command"))
                        {
                            command.SetValue("", "\"" + application + "\" \"%1\"");
                        }
                        progId_key.CreateSubKey("DefaultIcon").SetValue("", "\"" + icon + "\"");
                    }
                }
                // Now the extension
                using (var User_Ext = User_Classes.CreateSubKey("." + extension))
                {
                    User_Ext.SetValue("", progID);
                    User_Ext.CreateSubKey("DefaultIcon").SetValue("", "\"" + icon + "\"");
                }
                User_Explorer.CreateSubKey("OpenWithProgids").SetValue(progID, "0");
                using (RegistryKey User_Choice = User_Explorer.OpenSubKey("UserChoice"))
                {
                    if (User_Choice != null) User_Explorer.DeleteSubKey("UserChoice");
                    User_Explorer.CreateSubKey("UserChoice").SetValue("ProgId", progID);
                }
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
        }
