    let me know if its a serialization issue.
    
    [DataContract]  
    public class User
    {
        [DataMember]
        public int UserId { get; set; }
     
      [DataMember]
            public string Name { get; set; }
    
      [DataMember]
            public string FirstName { get; set; }
    
      [DataMember]
            public string LastName { get; set; }
    
      [DataMember]
            public virtual Collection<Achievement> Achievements { get; set; }
        }
    
       [DataContract]  
        public class Achievement
        {
    
      [DataMember]
            public int AchievementId { get; set; }
    
      [DataMember]
            public string Achievement { get; set; }
    
      [DataMember]
            public string Value { get; set; }
    
      [DataMember]
            public User User { get; set; }
        }
