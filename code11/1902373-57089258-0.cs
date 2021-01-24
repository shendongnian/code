      class User : IEquatable<User> {
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
    
        public override int GetHashCode() {
          return Id;
        }
      }
