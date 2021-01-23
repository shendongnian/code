    public class Person
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Age { get; set; }
    
        public Person() 
        {
        }
        public Person( IDataRecord record )
        {
            FirstName = (string) record["first_name"];
            LastName = (string) record["last_name"];
            Age = (double?) record["age"];
        }
    }
