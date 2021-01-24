    public class PersonViewModel : ViewModelBase
    {
        private readonly Person _person;
        public PersonViewModel(Person person)
        {
            _person = person;
        }
        public string Name 
        { 
           get => _person.Name; 
           set
           {
                var name = _person.Name;
                if (Set(ref name, value))
                    _person.Name = name;
           }
        }
    }
