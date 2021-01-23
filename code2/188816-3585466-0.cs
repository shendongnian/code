    private RoleLevel GetRole(int companyId)
    {
        var allRoles = Session.CreateCriteria<Role>().List<Role>();
    
        var role = Session.CreateCriteria<Role>("r")
            .CreateCriteria("Company", "c", JoinType.LeftOuterJoin)
            .Add(Restrictions.Eq("c.Id", companyId))
            .UniqueResult<Role>();
    
        return (role == null) ? RoleLevel.Restricted : role.RoleLevel;
    }
