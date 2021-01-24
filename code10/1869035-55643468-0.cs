    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
    {
       using (var subKey = baseKey.OpenSubKey("blah", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl))
       {
          if (subKey != null)
          {
             var value =  subKey.GetValue("Somekey");
          }
       }
    }
