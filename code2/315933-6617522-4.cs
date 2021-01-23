    public abstract class Role
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }
        
        public abstract void PerformRole();
    }
    public class SalesPerson : Role
    {
        public void PerformRole()
        {
            // Do something
        }
    }
