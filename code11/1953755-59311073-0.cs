    public class UserType
    {
        public string TypeName { get; set; }
        // Constructor creates an instance based on a string
        public UserType (string input)
        {
            TypeName = input;
        }
    }
    public class UserRole
    {
        public string RoleName { get; set; }
        // Static method returns an instance based on a string
        public static UserRole Parse(string input)
        {
            return new UserRole {RoleName = input};
        }
    }
    public class BookingPeriod
    {
        public string BookingPeriodName { get; set; }
    }
