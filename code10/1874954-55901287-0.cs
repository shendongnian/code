    public class User
    {
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public Role Role { get; set; }
    }
    public enum Role
    {
       Viewer,
       Developer,
       Manager
    }
