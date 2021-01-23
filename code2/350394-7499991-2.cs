        [DataContract]  
        public class User {   
        
        [DataMember]
        public int UserId { get; set; }     
        
        [DataMember]
        public string UserName { get; set; } 
        
        [DataMember]    
        public Role role { get; set; } }  
            
        [DataContract] 
        public class Role
        {
           [DataMember]
           public string Name { get; set; } 
        } 
