    public class Main {
        public UserDetail Details {get;set;}
    }
    
    public class Details {
        public Main Account {get;set;}
    }
    
    public class Main {
        public Guid UserDetailsId {get;set;}
    }
    
    public class Details {
        public Guid AccountId {get;set;}
    }
