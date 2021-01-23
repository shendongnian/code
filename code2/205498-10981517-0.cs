    public class Group
    {
        private Collection<Person> _persons;
    
        public Group(Collection<Person> persons)
        {
            if (persons == null)
                throw new ArgumentNullException("persons");
    
            _persons = persons;    
        }
        public IEnumerable<Person> Persons
        {
            get { return _persons; }
        }
    
        public void AddPerson(Person p)
        {
            if (p == null)
                throw new ArgumentNullException("p");
    
            _persons.Add(p);
            DoSideAffect();
        }
    }
    
    public class GroupRepository
    {
        public Group FindBy(Criteria c)
        {
            // Use whatever technology (EF, NHibernate, ADO.NET, etc) to retrieve the data
    
            var group = new Group(new Collection<Person>(listOfPersonsFromDataStore));
    
            return group;
        }
        public void Save(Group g)
        {
            // Use whatever technology to save the group
            // Iterate through g.Persons to persist membership information if needed
        }
    }
