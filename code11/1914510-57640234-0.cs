    public class Register : IPost, IReturn<RegisterResponse>, IMeta
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool? AutoLogin { get; set; }
        public string Continue { get; set; }
        public string ErrorView { get; set; }
        public Dictionary<string, string> Meta { get; set; }
    }
