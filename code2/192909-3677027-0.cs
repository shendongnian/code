    using PersonDto = DAL.IPerson;
    
    namespace BLL
    {
        public class Person : IPerson
        {
    
            private readonly PersonDto _person;
    
            public Person(PersonDto person)
            {
                _person = person;
            }
    
            public string Name
            {
                get { return _person.Name; }
            }
        }
    }
