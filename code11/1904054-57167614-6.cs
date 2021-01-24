    public class PersonViewModel
    {
        private readonly Person _person;
        public string FirstName => _person.FirstName;
        public PersonViewModel(Person person) // constructor
        {
            _person = person;
        }
    }
