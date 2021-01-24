    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public Person(string firstName = null, string lastName = null)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
