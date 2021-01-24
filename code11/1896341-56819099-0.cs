    public class User {
        public Guid Id {get;}
        public User() {
            Id = Guid.NewGuid();
        }
    }
    public class Answer {
        public Guid UserId{get;set;}
        public User User => AllUsers.Single(x => x.Id == UserId);
    }
