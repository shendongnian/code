    public class Actions{
       [Key]
       public int ActionId {get; set;}
       public string Action {get; set;}    
    }
    public class Users{
       [Key]
       public int UserId { get; set; }
       public string Name { get; set; }
       public string LastName { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public string Adress { get; set; }
       public string Gender { get; set; }
       public Nullable<DateTime > BirthDate { get; set; }
    }
    public class Roles{
       [Key]
       public int RoleId {get; set;}
       public string RoleName {get; set;}
       public string RolePermissions {get; set;} // You will store action IDs in "1,2,4,5"  this format
    }
    public class UserRole{
       [Key]
       public int Id {get; set;}
       public int UserId {get; set;}
       public int RoleId {get; set;}
    }
