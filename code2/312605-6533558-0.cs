    public static void CreateWithFullAccess(string targetDirectory)
        {
            try
            {
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                DirectoryInfo info = new DirectoryInfo(targetDirectory);
                SecurityIdentifier allUsersSid =
                new SecurityIdentifier(WellKnownSidType.LocalServiceSid,
                null);
                DirectorySecurity security = info.GetAccessControl();
                security.AddAccessRule(
                new FileSystemAccessRule(allUsersSid,
                FileSystemRights.FullControl,
                AccessControlType.Allow));
                info.SetAccessControl(security);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
