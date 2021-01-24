        class Person {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
            public virtual string Family { get; set; }
            public virtual string Gender { get; set; }
        }
    
        public class PersonNameModel : Person {
             [JsonIgnore]
             public override int Id { get; set; }
             [JsonIgnore]
             public override string Gender{ get; set; }
        }
