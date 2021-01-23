    public interface IDuck
    {
       void Swim();
    }
    public class Duck : IDuck
    {
       public void Swim()
       {
          //do something to swim
       }
    }
    public class ElectricDuck : IDuck
    {
       public void Swim()
       {
          if (!IsTurnedOn)
            return;
          
          //swim logic  
       }
    }
