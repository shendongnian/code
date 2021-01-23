    public class Employee
    {
        public bool IsContractEmployee
        {
           get;
           set;
        }
    }
    
    public class WageCalculator
    {
    
        private abstract class WageCalculAlgorithm
        { 
            public virtual decimal Calculate( Employee emp )
            {
                 // regular calc goes here
            }
        }
    
        private class ContractorCalculator : WageCalculAgorithm
        {
            public override decimal Calculate( Employee emp )
            {
                // contractor calc goes here
            }
        }
    
        public static decimal CalculateWageFor( Employee emp )
        {
           if( emp.IsContractEmployee )
                return new ContractorCalculator().Calculate(emp);
           else
                return new WageCalculAlgorithm().Calculate(emp);
        }
    }
