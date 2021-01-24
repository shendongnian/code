    public class Person
    {
        [Required]
        public virtual Address ClientAddress { get; set; }
    }
    public class Employee : Person ...
