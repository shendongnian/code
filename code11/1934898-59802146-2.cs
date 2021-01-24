    [DataContract]
    public class Person {
                public virtual int Id { get; set; }
                public virtual string Name { get; set; }
                public virtual string Family { get; set; }
                public virtual string Gender { get; set; }
    }
    public class PersonNameModel : Person {
                // included in JSON
                [DataMember]
                public override string Name { get; set; }
                [DataMember]
                public override string Family { get; set; }
    
                // other inherited properties will be ignored
    }
