    public class Person : Customer
    {
        [Column(Name="EmailAddress")]
        public string Email { get; set; }
    }
