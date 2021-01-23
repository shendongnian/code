    public class Employee
    {
       public bool isContractEmployee
          { get; set;}
    
       public abstract float CalCulatePayroll();   
    }
    
    
    public class FullTimeEmp : Employee
    {
       public override float CalCulatePayroll()
       {
       }
    }
    
    public class ContractEmp : Employee
    {
      public int NoofHR
          {get; set;}
    
      public override float CalCulatePayroll()
       {
           sal = nohr*money;
       }
    }
