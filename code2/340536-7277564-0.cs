     [Serializable]
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Person(String FirstName, String LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public Person()
            : this(String.Empty, String.Empty)
        {
        }
    }
    [Serializable]
    public class ViewModelBase
    {
    }
    [Serializable]
    public class SomePageViewModel : ViewModelBase
    {
        private Person currentperson;
        public Person CurrentPerson
        {
            get
            {
                if (currentperson == null)
                {
                    currentperson = new Person();
                }
                return currentperson;
            }
            set
            {
                currentperson = value;
            }
        }
        private List<Person> persons;
        public List<Person> Persons
        {
            get
            {
                if (persons == null)
                {
                    persons = new List<Person>();
                }
                return persons;
            }
            set
            {
                persons = value;
            }
        }
        public SomePageViewModel()
        {
        }
        public void RegisterPerson(String FirstName, String LastName)
        {
            Persons.Add(new Person(FirstName,LastName));
        }
        public void GetPersons()
        {
            /*Get Persons from database*/
        }
    }
