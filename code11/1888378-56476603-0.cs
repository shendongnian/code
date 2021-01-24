    public class MyObject {
      public MyObject(Employee employee, decimal payment) {
        if (null == employee) 
          throw new ArgumentNullException(nameof(employee));
    
        Employee = employee;
        Payment = payment;
      }
    
      public Employee Employee {get;}
      public Decimal Payment {get;}
    
      public int Id => Employee.Id;
      public string Name => Employee.Name
      public DateTime Birthday => Employee.Birthday
    } 
