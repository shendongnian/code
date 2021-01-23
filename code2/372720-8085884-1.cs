    if (myRole == User.Role.Admin)
    {
      return PrivilegeMap.Where(p => p.PrivilegeActionId == actionID).Select(p => p.AdminHasIt).First();
    }
    if (myRole == User.Role.Moderator)
    {
      return PrivilegeMap.Where(p => p.PrivilegeActionId == actionID).Select(p => p.ModeratorHasIt);
    }
    else
    {
      return false;
    }
