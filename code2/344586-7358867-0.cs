    class Employee
    {
       public int EmployeeID {get;set;}
       public DateTime Date {get;set;}
       public int PayID {get;set;}
    }
    
    class Employees : List<Employee>{}
    
    class MyDictionary : Dictionary<int,Employees> {}
