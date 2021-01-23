    public static class RolesEx
    {
      public static void CreateRole(string roleName, string description)  
      {  
        Roles.CreateRole(roleName);
    
        var c = new SqlConnection("connString");  
        var cmd = c.CreateCommand();
        cmd.CommandText =
          string.Format(
            "UPDATE aspnet_Roles SET Description = '{0}' WHERE ApplicationId = (SELECT ApplicationId FROM aspnet_Applications WHERE LoweredApplicationName = '{1}') AND  LoweredRoleName = '{2}'",
            description, Roles.ApplicationName.ToLower(), roleName.ToLower());
        cmd.CommandType = CommandType.Text;
        c.Open();
        var i = cmd.ExecuteNonQuery();
        c.Close();
      }
    }
