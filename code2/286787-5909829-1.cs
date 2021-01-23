    public class User
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
    }
    public static class SessionContext
    {
        public static User CurrentUser { get; set; }
    }
