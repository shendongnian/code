    public class Person
    {
        [Required] //Only works because the Guid is nullable
        public Guid? PersonId { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
    }
