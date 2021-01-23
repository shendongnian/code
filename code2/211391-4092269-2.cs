    class Person
    {
        public string Name { get; set; }
    
        // we add a copy method that returns a shallow copy...
        public Person Copy()
        {
            return (Person)this.MemberwiseClone();
        }   
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
                    // ...and here we return a copy instead of the contained object
                    yield return person.Copy();
                }
            }
        }
    }
