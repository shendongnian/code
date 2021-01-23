    public class User
    {
        public Role Role { get; set; }
    }
    public abstract class Role
    {
        abstract void DoRoleSpecificStuff();
    }
    public class Vendor : Role
    {
        public void DoRoleSpecificStuff()
        {
            /* ... */
        }
    }
    public class Employer : Role
    {
        public void DoRoleSpecificStuff()
        {
            /* ... */
        }
    }
    public class Advertiser : Role
    {
        public void DoRoleSpecificStuff()
        {
            /* ... */
        }
    }
