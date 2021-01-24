        //Data Access layer Persistance logic
    class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            // ORM Implementation here
            return new List<Person>();
        }
        public void Update(Person person)
        {
          // Update logic here
        }
    }
