     public bool RemoveUserFromAdminGroup(string computerName, string user)
     {
            try
            {
                var de = new DirectoryEntry("WinNT://" + computerName);
                var objGroup = de.Children.Find(Settings.AdministratorsGroup, "group");
                foreach (object member in (IEnumerable)objGroup.Invoke("Members"))
                {
                    using (var memberEntry = new DirectoryEntry(member))
                        if (memberEntry.Name == user)
                            objGroup.Invoke("Remove", new[] {memberEntry.Path});
                }
                
                objGroup.CommitChanges();
                objGroup.Dispose();
             
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
     }
