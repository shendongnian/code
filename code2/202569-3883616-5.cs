    class Person
    {
        string FirstName;
        string LastName;
        int Age;
        
        public int override GetHashCode()
        {
            return (FirstName == null ? 0 : FirstName.GetHashCode()) ^
                (LastName == null ? 0 : LastName.GetHashCode()) ^
                Age.GetHashCode();
        }
    }
