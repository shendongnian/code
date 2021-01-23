    public class BankService
    {
        public bool ProcessPayment(int employeeCode, MyProject.BankService.EmployeeType employeeType)
        {
            bool processed = false;
            // Boring code
            return processed;
        }
    }
    
    public void SomeMethod(int employeeCode)
    {
         var hrService = new HumanResourcesService();
         var employee = hrService.GetEmployee(employeeCode);
    
         var bankService = new BankService();
         bankService.ProcessPayment(employee.Code, employee.Type);
    }
