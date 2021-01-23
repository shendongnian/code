    public class Person
    {
        private 
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                // see how we can call a method below? or any code for that matter..
                _firstName = SanitizeName(value);
            }
        }
    }
