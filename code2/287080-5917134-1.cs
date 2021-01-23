    public class PeopleEnum : IEnumerable<Person>
    {
        public Person[] _people;
    
        public PeopleEnum(Person[] list)
        {
            _people = list;
        }
    
        public IEnumerator<Person> GetEnumerator()
        {
            foreach (Person person in _people)
                yield return person;
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
