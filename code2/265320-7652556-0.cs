    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DateRange("2010/12/01", "2010/12/16")]
        public DateTime DateOfBirth { get; set; }
    }
