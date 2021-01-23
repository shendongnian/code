    RegistryKey rk = LocalMachine.OpenSubKey(subkey, RegistryKeyPremissionsCheck.ReadWriteSubTree, RegistryRights.ChangePermissions | RegistryRights.ReadKey);//Get the registry key desired with ChangePermissions Rights.
    RegistrySecurity rs = new RegistrySecurity();
    rs.AddAccessRule(new RegistryAccessRule("Administrator", RegistryRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));//Create access rule giving full control to the Administrator user.
    rk.SetAccessControl(rs); //Apply the new access rule to this Registry Key.
    rk = LocalMachine.OpenSubKey(subkey, RegistryKeyPremissionsCheck.ReadWriteSubTree, RegistryRights.FullControl); // Opens the key again with full control.
    rs.SetOwner(new NTAccount("Administrator"));// Set the securitys owner to be Administrator
    rk.SetAccessControl(rs);// Set the key with the changed permission so Administrator is now owner.
