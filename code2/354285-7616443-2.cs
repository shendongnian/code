    List<string> outputRoleUserLIst2=roleUserList
        .Where(x => x != null && x.UserID != null && x.RoleID != null && missingRoleUserList
            .Where(y => y != null && y.UserID != null && y.RoleID != null && y.RoleID!=x.RoleID && y.UserID!=x.UserID)
            .FirstOrDefault()!=null)
        .Select(x => x.UserID + ",\"" + x.RoleID).Distinct().ToList();
