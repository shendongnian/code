    public struct Id<T> {
        public int? ID { get; }
        
        public static implicit operator Id<T>(int id) {
            return new Id<T>(id);
        }
        
        public Id(int? id) { ID = id; }
        
        public static bool operator ==(Id<T> lhs, Id<T> rhs) {
            return lhs.ID == rhs.ID;
        }
        public static bool operator !=(Id<T> lhs, Id<T> rhs) {
            return lhs.ID != rhs.ID;
        }
    }
    // usage:
    public class Person {
      public Id<Person> Id { get; set; }
    }
    
    public class Project {
      public Id<Project> Id { get; set; }
    }
