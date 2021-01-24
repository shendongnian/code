    PropertyInfo[] properties = typeof(RoleModel).GetProperties();
    foreach (PropertyInfo property in properties)
    {
        if(property.Name != "ID" && property.Name != "RoleName")
        {
            Type t = role.GetType();
            PropertyInfo p = t.GetProperty(property.Name);
            UserRoleModel urm = ((UserRoleModel)p.GetValue(role, null));
            // do something with urm
        }
    }
    return true;
