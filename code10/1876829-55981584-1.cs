        private void Serialise()
        {
            
            //prepare static data
            List<User> users = new List<User>()
            {
                new User() {key = "value1"},
                new User() {key = "value2"}
            };
            Roles roles = new Roles();
            roles.Users = users;
            roles.Role = "Admin";
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = roles
            };
            //serialise
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
        }
		
		public class Account
		{
			public string Email { get; set; }
			public bool Active { get; set; }
			public DateTime CreatedDate { get; set; }
			public Roles Roles { get; set; }
		}
		public class Roles
		{
			public List<User> Users { get; set; }
			public string Role { get; set; }
		}
		public class User
		{
			public string key { get; set; }
		}
		
