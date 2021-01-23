    public class UserCashAccount {
        public IList<UserDetail> Details {get;set;}
    }
    
    public class Details {
        public UserCashAccount Account {get;set;}
    }
    
    public class UserCashAccount {
        public Guid UserDetailsId {get;set;}
    }
    
    public class Details {
        public Guid AccountId {get;set;}
    }
