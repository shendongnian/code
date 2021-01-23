    public class UserMap : ClassMap<User>
    {
       public UserMap()
       {
          HasManyToMany(x => x.Roles)
                    .Table("RolesUsers")
                    .Access.AsCamelCaseField(Prefix.Underscore)
                    .ParentKeyColumn("UserId")
                    .ChildKeyColumn("RoleId")
                    .Cascade.All()
                    .Inverse();
       }
    }
