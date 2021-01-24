    public partial class Employee
    {
      public <DataType> EmpID {get; set;}
      public <DataType> FirstName {get; set;}
      public <DataType> LastName {get; set;}
    }
    public partial class Requestor
    {
      public <DataType> RequestorID {get; set;}
      public <DataType> EmpID {get; set;}
    
      public virtual Employee Employee {get; set;}
    }
    public partial class Transaction
    {
      public <DataType> TransID {get; set;}
      public <DataType>  RequestorID {get; set;}
      public <DataType> Amount {get; set;}
      public <DataType> TransType {get; set;}
    
      public virtual Requestor Requestor{get; set;}
    }
