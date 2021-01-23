    public abstract class Entity
    {
       private ILossCalculator _lossCalculator;
    
       protected Entity(Dependency a, OtherDependency b)
       {
           _lossCalculator = new DefaultLossCalculator(a, b);
       }
    
       protected Entity(ILossCalculator lossCalculator)
       {
           _lossCalculator = lossCalculator;
       }
    
       public decimal Loss
       {
          get
          {
             return _lossCalculator.CalculateLoss();
          }
       }
    }
    
    public class RiskEntity : Entity
    {
        public RiskEntity(Dependency a, Dependency b) : base(a, b)
        {
        }
    
        public RiskEntity(ILossCalculator lossCalculator) : base(lossCalculator)
        {
        }
    
        //rest of implementation
    }
    
    //Other derived class(es) omitted - you get the idea, though...
