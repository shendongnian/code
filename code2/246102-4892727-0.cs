    // My Core Immutable Type
    namespace MyProject {
      public sealed class Student { 
        private readonly string _name;
        public string Name { 
          get { return _name; }
        }
        public Student(string name) {
          _name = name;
        }
      }
    }
    
    // My Xml Serialization Type
    namespace MyProject.Serialization {
      public class SerializableStudent {
        public string Name;
      
        public SerializableStudent(Student source) {
          Name = source.Name;
        }
    
        public Student ConvertToStudent() {
          return new Student(Name);
        }
       
      }
    }
