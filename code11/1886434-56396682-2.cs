   public class User
    {
        public string Name { get; set; }
    }
    
    public class RoleBase
    {
        
    }
    public class RoleAdmin: RoleBase
    {
     public bool Action1 { get; set; }
     public bool Action2 { get; set; }
    }
    
    public class RoleNotAdmin: RoleBase
    {
        public bool Action3 { get; set; }
        public bool Action4 { get; set; }
    }
    
    public interface IPermission
    {
        bool IsAuthorization(RoleBase role, User user);
    }
    public class PermissionAdmin : IPermission
    {
        public bool IsAuthorization(RoleBase roleBase, User user)
        {
            var roleAdmin = roleBase as RoleAdmin;
            return true;
        }
    }
