    public class PersonViewModel
    {
        public Person Person { get; }
        public string FirstName => Person.FirstName;
        public PersonViewModel(Person person) // constructor
        {
            Person = person;
        }
    }
