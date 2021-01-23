    public interface IDuck
    {
       void Swim();
       // contract says that IsSwimming should be true if Swim has been called.
       bool IsSwimming { get; }
    }
    public class OrganicDuck : IDuck
    {
       public void Swim()
       {
          //do something to swim
       }
       bool IsSwimming { get { /* return if the duck is swimming */ } }
    }
    public class ElectricDuck : IDuck
    {
       bool _isSwimming;
       public void Swim()
       {
          if (!IsTurnedOn)
            return;
          
          _isSwimming = true;
          //swim logic  
          
       }
 
       public IsSwimming { get { return _isSwimming; } }
    }
