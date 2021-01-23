    /* Connection to Active Directory
     */
    DirectoryEntry workingOU = new DirectoryEntry();
    workingOU.Options.SecurityMasks = SecurityMasks.Owner | SecurityMasks.Group | SecurityMasks.Dacl | SecurityMasks.Sacl;
    workingOU.Path = "LDAP://WM2008R2ENT:389/ou=ForUser1,dc=dom,dc=fr";
    
    /* Retreive Obect security
     */
    ActiveDirectorySecurity adsOUSec = workingOU.ObjectSecurity;
    
    /* Ellaborate the user to delegate
     */
    NTAccount ntaToDelegate = new NTAccount("dom", "user1");
    SecurityIdentifier sidToDelegate = (SecurityIdentifier)ntaToDelegate.Translate (typeof(SecurityIdentifier));
    
    /* Specils Guids
     */
    Guid UserForceChangePassword = new Guid("00299570-246d-11d0-a768-00aa006e0529");
    Guid userSchemaGuid = new Guid("BF967ABA-0DE6-11D0-A285-00AA003049E2");
    Guid pwdLastSetSchemaGuid = new Guid("bf967a0a-0de6-11d0-a285-00aa003049e2");
    
    /* Ellaborate ACEs
     */
    ExtendedRightAccessRule erarResetPwd = new ExtendedRightAccessRule(ntaToDelegate, AccessControlType.Allow, UserForceChangePassword, ActiveDirectorySecurityInheritance.Descendents, userSchemaGuid);
    PropertyAccessRule parPwdLastSetW = new PropertyAccessRule(ntaToDelegate, AccessControlType.Allow, PropertyAccess.Write, pwdLastSetSchemaGuid, ActiveDirectorySecurityInheritance.Descendents, userSchemaGuid);
    PropertyAccessRule parPwdLastSetR = new PropertyAccessRule(ntaToDelegate, AccessControlType.Allow, PropertyAccess.Read, pwdLastSetSchemaGuid, ActiveDirectorySecurityInheritance.Descendents, userSchemaGuid);
    adsOUSec.AddAccessRule(erarResetPwd);
    adsOUSec.AddAccessRule(parPwdLastSetW);
    adsOUSec.AddAccessRule(parPwdLastSetR);
    
    workingOU.CommitChanges();
