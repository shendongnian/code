    public class SignUpModal
    {
        public int Id { get; set; }
        public object FirstName { get; set; }
        public object LastName { get; set; }
        public object UserName { get; set; }
        public string Email { get; set; }
        public object RoleId { get; set; }
        public string Password { get; set; }
        public object IsActive { get; set; }
        public object SecretKey { get; set; }
        public object Token { get; set; }
        public object Role { get; set; }
        public object RolePermissions { get; set; }
        public object ImagePath { get; set; }
        public object CurrentDate { get; set; }
    }
    public class MessageArgument
    {
        [JsonProperty("signUpModal")]
        public SignUpModal SignUpModal { get; set; }
    }
    public class Parameter
    {
        [JsonProperty("messageFormat")]
        public string MessageFormat { get; set; }
        [JsonProperty("messageArguments")]
        public IList<MessageArgument> MessageArguments { get; set; }
    }
