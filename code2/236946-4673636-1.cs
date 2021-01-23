    public class PersonsRepositoryInMemory: IPersonsRepository
    {
        public IEnumerable<Person> GetPersons()
        {
            return Enumerable.Range(1, 10).Select(i => new Person {
                FirstName = "first " + i,
                FirstName = "last " + i
            });
        }
    }
