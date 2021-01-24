    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        [Required]
        public virtual Address PersonAddress { get; set; }
    }
    public class Employee : Person
    {
        // Other properties that make Employee unique go here
    }
    public class Client : Person
    {
        // Other properties that make Client unique go here
    }
