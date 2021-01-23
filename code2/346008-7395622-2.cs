    public class User
    {
        public Roles Roles { get; set; }
    }
    [Flags]
    public enum Roles
    {
        Advertiser = 0x0,
        Employer = 0x1,
        Vendor = 0x2      
    }
