    class EmployeeFactory
    {
         public Employee Create(int id, string name)
         {
             Employee instance = new Employee(id, name);
             
             var handler = EmployeeCreated;
             if (handler != null)
             {
                  EmployeeEventArgs e = new EmployeeEventArgs(instance);
                  handler(e);    
             }
             
             return instance;
         }
         public event EventHandler<EmployeeEventArgs>  EmployeeCreated;
    }
