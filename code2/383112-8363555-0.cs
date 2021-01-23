    public class Customer
    {
      public int Id { get; set;}
      public string Name { get; set;}
    
      public int CompanyId { get; set;}
    }
    public class Company
    {
      public int CompanyId;
      //company fields
    }
    
    // .. on your business layer if you need to use Company data:
    // examine your Customer instance as "customer"
    
    Company userCompany = GetCompanyWithId(customer.CompanyId);
