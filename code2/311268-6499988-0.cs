      public class Person
        {
        public string FirstName {get; set;}
        public string LastName { get; set;}
        }
        
        
        var people = new List<Person>();
        
                    people.Add(new Person
                                   {
                                       FirstName = "Amy",
                                       LastName = "Apple"
                                   });
        
                    people.Add(new Person
                                   {
                                       FirstName = "Andy",
                                       LastName = "Apple"
                                   });
        
                    people.Add(new Person
                                   {
                                       FirstName = "Charlie",
                                       LastName = "Coconut"
                                   });
        
        var sortedPeople = people.OrderBy(f => f.LastName).ThenByDescending(f => f.FirstName);
