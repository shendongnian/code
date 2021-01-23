    public class Member {
        public IList<Role> Roles { get; private set; }
    
        public Member(){
            Roles = new List<Role>();
        }
    }
    
    public class Role {
    
        public string SomeGlobalProperty { get; set; }
    
    }
    
    public class Coach : Role {
        
        public string SomeSpecificProperty { get; set; }
    }
    
    public class Practitioner : Role {
        
        public string SomeSpecificProperty { get; set; }
    }
