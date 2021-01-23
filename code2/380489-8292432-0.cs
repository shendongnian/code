    public class PersonalInfo 
    {
       public string FirstName { get; set;}
       public string LastName { get; set;}
       // more properties
    }
    public class EmployeeModel 
    {
        // remove List<> if you always just have 1 personalinfo child element
        public List<PersonalInfo> {get; set;}   
        public List<EmploymentInfo> {get; set;}
        // more properties
    }
