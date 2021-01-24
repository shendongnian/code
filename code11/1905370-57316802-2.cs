    //the class of the contact objects
    public class Contact
    {
        public string FirstName;
        public string LastName;
        
        public string FullName => $"{FirstName} {LastName}"; // For displaying
        public Contact(){}
        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
