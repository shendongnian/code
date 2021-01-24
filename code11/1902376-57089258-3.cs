      class User : IEquatable<User> {
        // Dangerous practice: Id (and name) usually should be readonly:
        // we can put instance into, say, dictionary and then change Id loosing the instance 
        public int Id { get; set; }
        public string name { get; set; }
    
        public bool Equals(User other) {
          if (null == other)
            return false;
    
          return  
            Id == other.Id && 
            string.Equals(name, other.name, StringComparison.OrdinalIgnoreCase);
        }
    
        public override bool Equals(object obj) => Equals(obj as User);
    
        public override int GetHashCode() => Id;
      }
