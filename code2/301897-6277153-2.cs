    internal class UserDetails
        {
            public UserDetails(User u)
            {
                this.Forename = u.Username.Split('.')[0].ToTitleCase();
                this.Surname = u.Username.Split('.')[1].ToTitleCase();
                this.UserId = u.SalesUserId;
                this.Username = u.Username;
            }
    
            public string Username { get; set; }
            public string Surname { get; set; }
            public string Forename { get; set; }
    
            public int UserId { get; set; }
    
        }
