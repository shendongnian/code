        // I would always make these classes serializable so you can directly 
        // also see, edit and save them via the Inspector
        [Serializable]
        public class User 
        {
            public string username;
            public string email;
        
            public User() 
            {
            }
        
            public User(string username, string email) 
            {
                this.username = username;
                this.email = email;
            }
        }
