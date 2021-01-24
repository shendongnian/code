    List<UserInRoleVM> users = new List<UserInRoleVM>();
    using (var context = new DataContext())
    {
       var Parameter = new SqlParameter("@p0", code);
       users = context.Database.SqlQuery<UserInRoleVM>("exec usp_GetUsrsofRole  @p0", Parameter).ToList();
    }
    return users;
