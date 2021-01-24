    public class Person
    {
        private Lazy<string> _fullname;
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _fullname = new Lazy<string>($"{FirstName} {LastName}");
        }
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => _fullname.Value;
    }
