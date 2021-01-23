    public class Person2
    {
        private readonly int _arbitraryNumber;
        private readonly Person _person;
        public Person2(Person person, int arbitraryNumber)
        {
            _arbitraryNumber = arbitraryNumber;
            _person = person;
        }
        public string FullName
        {
            get
            {
                return String.Format("{0}, {1} - {2}", _person.LastName, _person.FirstName, _arbitraryNumber);
            }
        }
    }
