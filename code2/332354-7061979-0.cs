    public bool RenameUser(string oldLoginName, string newLoginName)
    {
        bool renamed = false;
        try
        {
            using (DirectoryEntry AD = new
                       DirectoryEntry("WinNT://" + Environment.MachineName + ",computer"))
            {
                try
                {
                    using (DirectoryEntry NewUser = AD.Children.Find(oldLoginName, "user"))
                    {
                        if (NewUser != null)
                        {
                            NewUser.Rename(newLoginName);
                            renamed = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //TODO: Log
                }
            }
        }
        catch (Exception ex)
        {
             //TODO: Log
        }
        return renamed;
    }
