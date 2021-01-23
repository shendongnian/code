    int roleid;
    var allowedRoles = new[] {5, 15};
    foreach (data r in dataList) {
        using (DataContext communityContext = new DataContext()) {
            roleid = communityContext.UserRoles
                .First(x=> x.UserID == r.ClientId && allowedRoles.Contains(x.RoleID))
                .RoleID;            
        }
    }
