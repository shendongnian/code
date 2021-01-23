    if(myRole != User.Role.Admin && myRole != User.Role.Moderator)
      return false;
    DataRow[] result = PrivilegeMap.Select("privilegeActionId=" + (int)actionId);
    if (myRole == User.Role.Admin)
    {
      return Convert.ToBoolean(result[0]["adminHasIt"]);
    }
    if (myRole == User.Role.Moderator)
    {
      return Convert.ToBoolean(result[0]["moderatorHasIt"]);
    }
