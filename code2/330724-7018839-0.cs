    public void CreatePrivateDirectory(string path)
      {
         DirectorySecurity directorySecurity = new DirectorySecurity();
         SecurityIdentifier userSid = WindowsIdentity.GetCurrent().User;
         directorySecurity.AddAccessRule(new FileSystemAccessRule(userSid, FileSystemRights.FullControl,
                                                                  InheritanceFlags.ContainerInherit |
                                                                  InheritanceFlags.ObjectInherit,
                                                                  PropagationFlags.None, AccessControlType.Allow));
         if(!Directory.Exists(path))
         {
            Directory.CreateDirectory(path, directorySecurity);
         }
      }
