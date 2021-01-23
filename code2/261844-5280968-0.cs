    public class Company
    {
        public string CompanyID {get;set;}
        List<Employee> Employees {get;set;}
        List<ShareHolder> ShareHolders {get;set;}
    }
    
    public class Employee
    {
        public string CompanyID {get;set;}
        //...
    }
    
    public class ShareHolder
    {
        public string CompanyID {get;set;}
        //..
    }
