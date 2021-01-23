    class Person
    {
        public EmploymentStatus EmploymentStatus { get; set; }
    }
    class EmployedPerson : Person
    {
        public string Occupation { get; set; }
        public Company Employer { get; set; }
    }
