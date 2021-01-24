    internal class Options
    {
        [Option("username", SetName = "auth")]
        public string Username { get; set; }
    
        [Option("password", SetName = "auth")]
        public string Password { get; set; }
    
        [Option("guestaccess", SetName = "guest")]
        public bool GuestAccess { get; set; }
    }
