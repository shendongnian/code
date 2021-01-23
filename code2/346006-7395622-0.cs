    public class User
    {
        public Role Role { get; set; }
    }
    public abstract class Role
    {
    }
    public class Vendor : Role
    {
    }
    public class Employer : Role
    {
    }
    public class Advertiser : Role
    {
    }
