    /// <summary>
    /// This is your main entity, while it may seem anemic, it is only because 
    /// it is simplistic.
    /// </summary>
    class Person
    {
        public string Id { get; set; }
        public string BirthPlace { get; set; }
        DateTime birthDate;
        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set
            {
                if (this.birthDate != value)
                {
                    this.birthDate = value;
                    DomainEvents.Raise(new BirthDateChangedEvent(this.Id));
                }
            }
        }
    }
    /// <summary>
    /// Udi Dahan's implementation.
    /// </summary>
    static class DomainEvents
    {
        public static void Raise<TEvent>(TEvent e) where TEvent : IDomainEvent
        {
        }
    }
    interface IDomainEvent { }
    /// <summary>
    /// This is the interesting domain event which interested parties subscribe to 
    /// and handle in special ways.
    /// </summary>
    class BirthDateChangedEvent : IDomainEvent
    {
        public BirthDateChangedEvent(string personId)
        {
            this.PersonId = personId;
        }
        public string PersonId { get; private set; }
    }
    /// <summary>
    /// This can be associated to a Unit of Work.
    /// </summary>
    interface IPersonRepository
    {
        Person Get(string id);
        void Save(Person person);
    }
    /// <summary>
    /// This can implement caching for performance.
    /// </summary>
    interface IBirthPlaceRepository
    {
        bool IsSpecial(string brithPlace);
        string GetBirthPlaceFor(string birthPlace, DateTime birthDate);
    }
    interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
    static class UnitOfWork
    {
        public static IUnitOfWork Start()
        {
            return null;
        }
    }
    class ChangeBirthDateCommand
    {
        public string PersonId { get; set; }
        public DateTime BirthDate { get; set; }
    }
    /// <summary>
    /// This is the application layer service which exposes the functionality of the domain 
    /// to the presentation layer.
    /// </summary>
    class PersonService
    {
        readonly IPersonRepository personDb;
        public void ChangeBirthDate(ChangeBirthDateCommand command)
        {
            // The service is a good place to initiate transactions, security checks, etc.
            using (var uow = UnitOfWork.Start())
            {
                var person = this.personDb.Get(command.PersonId);
                if (person == null)
                    throw new Exception();
                person.BirthDate = command.BirthDate;
                // or business logic can be handled here instead of having a handler.
                uow.Commit();
            }
        }
    }
    /// <summary>
    /// This view model is part of the presentation layer.
    /// </summary>
    class PersonViewModel
    {
        public PersonViewModel() { }
        public PersonViewModel(Person person)
        {
            this.BirthPlace = person.BirthPlace;
            this.BirthDate = person.BirthDate;
        }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
    }
    /// <summary>
    /// This is part of the presentation layer.
    /// </summary>
    class PersonController
    {
        readonly PersonService personService;
        readonly IPersonRepository personDb;
        public void Show(string personId)
        {
            var person = this.personDb.Get(personId);
            var viewModel = new PersonViewModel(person);
            // UI framework code here.
        }
        public void HandleChangeBirthDate(string personId, DateTime birthDate)
        {
            this.personService.ChangeBirthDate(new ChangeBirthDateCommand { PersonId = personId, BirthDate = birthDate });
            Show(personId);
        }
    }
    interface IHandle<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent e);
    }
    /// <summary>
    /// This handler contains the business logic associated with changing birthdates. This logic may change
    /// and may depend on other factors.
    /// </summary>
    class BirthDateChangedBirthPlaceHandler : IHandle<BirthDateChangedEvent>
    {
        readonly IPersonRepository personDb;
        readonly IBirthPlaceRepository birthPlaceDb;
        readonly DateTime importantDate;
        public void Handle(BirthDateChangedEvent e)
        {
            var person = this.personDb.Get(e.PersonId);
            if (person == null)
                throw new Exception();
            if (person.BirthPlace != null && person.BirthDate < this.importantDate)
            {
                if (this.birthPlaceDb.IsSpecial(person.BirthPlace))
                {
                    person.BirthPlace = this.birthPlaceDb.GetBirthPlaceFor(person.BirthPlace, person.BirthDate);
                    this.personDb.Save(person);
                }
            }
        }
    }
