    public List<User> usersPerRole(string role)
    {
     using(Entities context is new Entities())
     {
      return context.Role.FirstOrDefault<Role>(r => r.ID == role).Include("UsersInRole")
     }
    }
