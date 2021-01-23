    public class Company
    {
        private List<Person> _persons;
        public class PersonsIndexer
        {
            Company _owner;
            public PersonsIndexer(Company owner)
            {
                _owner = owner;
            }
            public Person this[string name]
            { 
                get
                {
                     return _owner._persons.FirstOrDefault(x=>x.Name == name); // or whatever code you have there
                }
            }
        }
        
        public PersonsIndexer Persons{ get; private set; }
        public Company() 
        {
            Persons = new PersonsIndexer(this);
        }
 
    }
