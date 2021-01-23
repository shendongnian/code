    var result = PrivilegeMap.Where(p => p.PrivilegeActionId == actionID).Select(p => new{p.ModeratorHasIt, p.AdminHasIt}).First()
    if (myRole == User.Role.Admin)
    {
      return result.AdminHasIt;
    }
    if (myRole == User.Role.Moderator)
    {
      return result.ModeratorHasIt;
    }
    else
    {
      return false;
    }
