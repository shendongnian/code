    public class PersonService
    {
        private readonly IPersonRepository repository;
        public PersonService(IPersonRepository repository)
        {
            this.repository = repository;
        }
        public IList<Person> PeopleOverEighteen
        {
            get
            {
                return (from e in repository.Entities where e.Age > 18 select e).ToList();
            }
        }
    }
