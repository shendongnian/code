    public static UserPrincipal GetManager(UserPrincipal user)
    {
      var userEntry = user.GetUnderlyingObject() as DirectoryEntry;
      if (userEntry.Properties["manager"] != null
        && userEntry.Properties["manager"].Count > 0)
      {
        string managerDN = userEntry.Properties["manager"][0].ToString();
        return UserPrincipal.FindByIdentity(user.Context,managerDN);
      }
      else
        throw new UserHasNoManagerException();
    }
    class UserHasNoManagerException : Exception
    { }
