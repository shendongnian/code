      namespace MyClasses {
        ...
        public static class PersonHelper {
          ...
          public static Person Person(string name) {
            //TODO: having name you should return Person instance, 
            // e.g. with a help of some dictionary:
            return Person.AllPersons.TryGetValue(name, out var result) 
              ? result
              : null;
         }
       }
