       public class Person {
         // Simplest, but not thread safe
         private static Dictionary<string, Person> s_AllPersons = new
           Dictionary<string, Person>();
         public Person(string name) {
           // When Person created we put the instance into the dictionary
           s_AllPersons.Add(name, this);
           Name = name;
         }
         public string Name {get;} 
         public static IReadOnlyDictionary<string, Person> AllPersons => s_AllPersons;
         ...
       }
