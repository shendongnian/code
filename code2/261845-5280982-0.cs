    public class Person
    {
        public string Name {get;set;}
    }
    
    public class Employee : Person
    {
        public Company Workplace {get;set;} // might be List<Company> depending on your application needs
    }
    
    public class ShareHolder : Person
    {
        public List<Company> OwnedCompanies {get;set;}
    }
