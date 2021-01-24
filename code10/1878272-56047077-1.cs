    public class PersonWrapper : INameable
    {
        private readonly Person _person;
        public PersonWrapper(Person person)
        {
            _person = person ?? throw new ArgumentNullException(nameof(person));
        }
        public string Name => _person.Name;
        public string Surname => _person.Surname;
    }
