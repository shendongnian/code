      interface IUsernamePassword
      {
        string Username { get; set; }
        string Password { get; set; }
      }
      class Account : IUsernamePassword
      {
        public string Username { get; set; }
    
        public string Password { get; set; }
      }
