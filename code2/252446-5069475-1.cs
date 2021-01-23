    public class Person
    {
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string EmployeeNumber { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Contract> Contracts { get; }
    }
