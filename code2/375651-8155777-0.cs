    public class PersonService
    {
        public PersonService(IStore<Person> store)
        {
           this.store = store;
        }
        public void ChangeName(object key, string name)
        {
           var person = store.GetPerson(key);
           person.Name = name;
           store.CommitToDatabase(person);
        }
    }
