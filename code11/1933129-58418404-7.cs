    public class Role
    {
        public ICollection<RolePermission> RolePermissions { get; }
        public ICollection<RoleCategory> RoleCategories { get; }
    }
    public class RolePermission
    {
        public Permission Permission { get; }
    }
    public class RoleCategory
    {
        public Category Category { get; }
        public CategoryType CategoryType { get; }
    }
    public class Category { }
    public class CategoryType { }
    public class Permission { }
