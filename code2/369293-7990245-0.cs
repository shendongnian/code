    class EmployeeManager()
    {
       ...
       
       public void CreateEmployee(Employee employee)
       {
           dao.Add(employee);
       }
       public void CreateEmployees(List<Employee> employees)
       { 
           dao.AddMany(employees);
       }
      
       ...
       public List<Employee> GetAllEmployees()
       {
           List<Employee> employees = dao.GetAll();
           employees.Sort();
       }
       ...
    }
    class Employee()
    {
       Employee(string name, string job)
       {
          Name = name;
          Job = job;
       }
       ...
 
       string Name { get; set; }
       string Job { get; set; }
    }
    class EmployeeDAO()
    {
       ...
       public List<Employee> GetAllEmployees() 
       {
            List<Employee> employees = new List<Employee>;
            
            //parse all rows and make make employee objects out of them.
            
            return employees;           
       }
    }
