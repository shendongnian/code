    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
