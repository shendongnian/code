        //Application logic
    class PersonViewModel
    {
        private readonly IPersonRepository _personRepository;
        public PersonViewModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public ObservableCollection<Person> Persons
        {
            get { return new ObservableCollection<Person>(_personRepository.GetAll()); }
        }
    }
