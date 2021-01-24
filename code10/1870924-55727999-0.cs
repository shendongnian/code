    public class AuthorizeRoles : Attribute
    {
    	public string Roles { get; private set; }
    	
        public AuthorizeRoles(params Role.MyEnum[] roles)
        {
            string allowed = string.Join(", ", roles);
            Roles = allowed;
        }
    }
    
    public class Role
    {
        public readonly string Name;
    
        public enum MyEnum
        {
            Admin,
            Manager
        }
    
        public Role(string name)
        {
            Name = name;
        }
    
        public override string ToString()
        {
            return Name;
        }
    }
    // ...
    [AuthorizeRoles(Role.MyEnum.Admin)]
    public IActionResult Index()
    {
        // ...
    }
