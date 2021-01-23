    var empDetails = from u in ObjectContext.USERS 
                     join ed in ObjectContext.USERS_EMPLOYEE_DETAILS on u.UserID equals ed.UserID 
                     join r in ObjectContext.ROLES_FOR_USERS on u.UserID equals r.UserID 
                     join ro in ObjectContext.ROLES on r.RoleID equals ro.RoleID 
                     where (r.HospitalID == Context.CurrentUser.HIdentity.HospitalID) 
                     where(r.RoleID!= 4) 
                     select new Models.AdminModelSettings.EmployeeDetailsForGivenHospital 
                     { 
                         UserName = u.UserName, 
                         EmployeeId = ed.ID, 
                         EmployeeDesignation = ed.Designation, 
                         RoleID = r.RoleID, 
                         RoleName = r.RoleID == 1 || r.RoleID == 2 || r.RoleID == 3 ? ro.RoleName : null
                     });
    //group our results and order the group by the role id
    var temp = rows.GroupBy(row => row.ID).Select(g => new { First = g.OrderBy(r => r.RoleID).First(), Last = g.OrderByDescending(r => r.RoleID).First() });
         
    //select the data into the shape that we want
    var query = temp.Select(result => new Models.AdminModelSettings.EmployeeDetailsForGivenHospital
    {
        UserName = result.First.UserName,
        EmployeeId = result.First.ID,
        EmployeeDesignation = result.First.Designation,
        RoleID = result.First.RoleID,
        AdditionalRoleID = AdditionalRoleID = result.Last.RoleID
    });
