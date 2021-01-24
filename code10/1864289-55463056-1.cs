    public class Parameter
    {
        public string messageFormat { get; set; }
        public List<MessageArgument> messageArguments { get; set; }
    }
    
    class MessageArgument {
        public SignUpModal SignUpModal {get; set;}
    }
    
    public class SignUpModal
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public int? SecretKey { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string RolePermissions { get; set; }
        public string ImagePath { get; set; }
        public string CurrentDate { get; set; }
    }
