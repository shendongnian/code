    public class Vote : Entity
    {
        public User User {get;set;}
        public int VoteDirection {get;set;} // 1 or -1
        // any other info...
    }
