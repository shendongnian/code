    class Person {
         ...
         public bool Equals(Object o) {
              return (Person)o.LastName.Equals(this.LastName);
         }
     }
