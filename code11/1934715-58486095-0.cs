    public class Country {}
    public class Company {}
    public class Person
    {
        public int CountryOfBirthId { get; set; }
        public virtual Country CountryOfBirth { get; set; }
        public int EmployerId { get; set; }
        public virtual Company Employer { get; set; }
    }
