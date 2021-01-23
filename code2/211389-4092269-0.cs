    class Person
    {
        public string Name { get; set; }
    }
    class Group
    {
        private readonly IEnumerable<Person> _persons;
        public Group(IEnumerable<Person> persons)
        {
            _persons = new ReadOnlyCollection<Person>(persons.ToList());
        }
        public IEnumerable<Person> Persons
        {
            get
            {
                foreach (var person in _persons)
                {
                    yield return person;
                }
            }
        }
    }
