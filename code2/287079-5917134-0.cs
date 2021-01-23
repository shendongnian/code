    public class PeopleEnum : IEnumerable
    {
        public Person[] _people;
    
        public PeopleEnum(Person[] list)
        {
            _people = list;
        }
    
        public IEnumerator GetEnumerator()
        {
            foreach (Person person in _people)
                yield return person;
        }
    }
