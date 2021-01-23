    public class AdminUserOverride : IAutoMappingOverride<AdminUser>
    {
      public void Override(AutoMapping<AdminUser> mapping)
      {
        mapping.HasManyToMany(x => x.Roles); // and possibly other options here
      }
    }
