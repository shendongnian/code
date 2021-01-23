    static void DeleteUserChoiceKey(RegistryKey extensionKey)
    {
        const string userChoiceKeyName = "UserChoice";
        using (RegistryKey userChoiceKey =
            extensionKey.OpenSubKey(userChoiceKeyName,
                RegistryKeyPermissionCheck.ReadWriteSubTree,
                RegistryRights.ChangePermissions))
        {
            if (userChoiceKey == null) { return; }
            string userName = WindowsIdentity.GetCurrent().Name;
            RegistrySecurity security = userChoiceKey.GetAccessControl();
            AuthorizationRuleCollection accRules =
                security.GetAccessRules(true, true, typeof(NTAccount));
            foreach (RegistryAccessRule ar in accRules)
            {
                if (ar.IdentityReference.Value == userName &&
                    ar.AccessControlType == AccessControlType.Deny)
                {
                    security.RemoveAccessRuleSpecific(ar); // remove the 'Deny' permission
                }
            }
            userChoiceKey.SetAccessControl(security); // restore all original permissions
                                                      // *except* for the 'Deny' permission
        }
        extensionKey.DeleteSubKeyTree(userChoiceKeyName, true);
    }
