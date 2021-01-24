    public class Person
    {
        [Required]
        public virtual Address PersonAddress { get; set; }
    }
    public class Employee : Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class Client : Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
