    @{
        string htmlstring = "";
        htmlstring += "<select id='userRoles'>";
        foreach (Role role in ViewBag.Roles)
        {
            htmlstring += "<option value='" + role.RoleID + "'>" + role.RoleName + "</option>";
        }
        htmlstring += "</select>";
    }
