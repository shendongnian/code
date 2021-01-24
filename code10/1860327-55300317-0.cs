            public string RemoveUser(string machineId, string userName)
        {
            string result = null;
            try
            {
                // Create scope and set to computer root.
                ManagementScope scope = new ManagementScope(@"\\" + machineId + @"\root\cimv2");
                // Connect.
                scope.Connect();
                // Create the query for user profiles and a searcher.
                SelectQuery query = new SelectQuery("Win32_UserProfile");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                // Go through each WMI Instance
                foreach (ManagementObject mo in searcher.Get())
                {
                    // Normalize username
                    string normalUser = mo["LocalPath"].ToString().Split('\\').Last(); 
                    // Check whether this is the user to be deleted
                    if (normalUser == userName)
                    {
                        mo.Delete();
                        result = "Found user: " + userName + ". Deleting...";
                    }
                }
                // This code deletes a user login
                //DirectoryEntry locaDirectoryEntry = new DirectoryEntry("WinNT://" + machineId);
                //DirectoryEntry user = locaDirectoryEntry.Children.Find(userName);
                //locaDirectoryEntry.Children.Remove(user);
                //locaDirectoryEntry.CommitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
