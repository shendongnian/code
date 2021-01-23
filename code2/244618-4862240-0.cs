    public class Person
    {
        public string TestName { get; set; }
    
        public string FirstName { get; set; }
    
        [Browsable(false)]
        public string MiddleName { get; set; }
    
        public string LastName { get; set; }
    }
