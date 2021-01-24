        public class Person
        {
            private string _firstName;
            private string _lastName;
            private Lazy<string> _fullName;
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
            public string FullName => _fullName.Value;
            private void UpdateFullName()
            {
                _fullName = new Lazy<string>(()=> $"{FirstName} {LastName}");
            }
        }
