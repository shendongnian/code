    public class User {
        public User() {
        
        }
        public AddAssociatedUser() {
            this.Associated = new User();
        }
        public User Associated { get; set; }
    }
