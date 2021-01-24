    public MainViewModel(ISomeService someService)
    {
        _someService = someService;
        _person = _someService.GetPerson("John");
        //etc
    }
    public interface ISomeService
    {
        Person GetPerson(string name);
    }
    public class SomeService : ISomeService
    {
        private List<Person> personRepository;
     
        //insert constructor...
        public Person GetPerson(string name)
        {
            return personRepository.Single(person => person.Name == name);
        }
    }
