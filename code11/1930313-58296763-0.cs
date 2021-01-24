    public class Employee
    {
      public <DataType> EmpID {get; set;}
      public <DataType> FirstName {get; set;}
      public <DataType> LastName {get; set;}
    }
    public class Requestor
    {
      public <DataType> RequestorID {get; set;}
      public Employee EmpID {get; set;}
    }
    public class Transaction
    {
      public <DataType> TransID {get; set;}
      public <DataType> RequestorID {get; set;}
      public Requestor Amount {get; set;}
      public <DataType> TransType {get; set;}
    
    }
