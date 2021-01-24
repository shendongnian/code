        public class Person
        {
            private string _firstName;
            private string _lastName;
            public string FirstName
            {
                get => _firstName;
                set
                {
                    _firstName = value;
                    UpdateFullName();
                }
            }
            public string LastName
            {
                get => _lastName;
                set
                {
                    _lastName = value;
                    UpdateFullName();
                }
            }
            public string FullName { get; private set; }
            private void UpdateFullName()
            {
                FullName = $"{FirstName} {LastName}";
            }
        }
