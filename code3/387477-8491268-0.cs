    public class LoginResponse
    {
        public User User { get; set; }
        public string Message { get; set; }
        public bool IsSuccessful
        {
            get { return User != null; }
        }
    }
