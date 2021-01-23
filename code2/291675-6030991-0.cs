    public class Person
    {
        private string _FirstName;
        public string FirstName 
        { 
            get
            {
                return _FirstName;
            }
            set
            {
                SomeMethod();
                _FirstName = value;
            }
        }
        private void SomeMethod()
        {
            //do something
        }
    
    }
