        public class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
                FullName = $"{FirstName} {LastName}";
            }
            public string FirstName { get; }
            public string LastName { get; }
            public string FullName { get; }
        }
