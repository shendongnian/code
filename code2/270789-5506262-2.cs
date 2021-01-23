    public class Person
    {
        [Key]
        public int Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("EmployeeType")]
        public int EmployeeTypeKey { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
    }
