    public class Employee
    {        
         public abstract int CalculateSalary();
    }
   
    public class RegularEmployee : Employee
    {
        public int NumOfWeeklyHours { get; set; }
        public int CalculateSalary()
        {
                // TODO: Implement
        }
    }
    public class ContractEmployee : Employee
    {
        public int FixedBasis { get; set; }
        public override int CalculateSalary()
        {
            // TODO: Implement
        }
    }
    public class Manager
    {
        public List<Employee> InChargeOf { get; set; }
    }
    public class PayRoll
    {
        public int CalculateSalaries(List<Employee> le)
        {
             return le.Sum(e => e.CalculateSalary());
        }
    }
