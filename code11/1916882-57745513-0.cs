    namespace LoginPage.Models
    {
        public class User
        {
            [PrimaryKey]
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
    
            public override string ToString()
            {
                return this.Email + "," + this.Password;
            }
        }
    }
