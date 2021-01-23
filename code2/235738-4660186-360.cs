    public class Person {
        public string Name { get; set; }
    }
    var people = new List<Person>();
    people.Add(null);
    var names = from p in people select p.Name;
    string firstName = names.First(); // Exception is thrown here, but actually occurs
                                      // on the line above.  "p" is null because the
                                      // first element we added to the list is null.
