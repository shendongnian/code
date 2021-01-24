Changes the name of this System.DirectoryServices.DirectoryEntry object.
and it does not change the Display Name. Following snippet will update the User object's DisplayName using PrincipalContext and UserPrincipal.
    string userNameToUpdate = "userNameToLookup";
    string modifiedDisplayName = "cn=NewName in Display";
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.Name, userNameToUpdate);
    user.DisplayName = modifiedDisplayName;
    user.Save();
If you are interested in using the DirectoryEntry, then you have to update the value of the property for that UserObject.
    existingUser.Properties["displayname"].Value = "cn=YourNewValue";
    existingUser.CommitChanges();
