    public class UserRole
    {
        public string RoleName { get; private set; }
        // Static method returns an instance based on a string
        public static UserRole Parse(string name)
        {
            return new UserRole {RoleName = name};
        }
    }
    public class UserType
    {
        public string TypeName { get; private set; }
        // Constructor creates an instance based on a string
        public UserType (string name)
        {
            TypeName = name;
        }
    }
    public class BookingPeriod
    {
        public string Name { get; set; }
    }
