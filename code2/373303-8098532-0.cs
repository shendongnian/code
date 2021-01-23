    public interface ILossCalculator
    {
       decimal CalculateLoss(); //maybe needs parameters, perhaps even the Entity itself?
    }
    
    public class DefaultLossCalculator : ILossCalculator
    {
       public DefaultLossCalculator(Dependency a, OtherDependency b)
       {
           //just an example, but here we inject the other classes that the 
           //default implementation requires to do the calculation.
       }
    
       public decimal CalculateLoss()
       {
           //default implementation ...
           return totalLoss;
       }
    }
