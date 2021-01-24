    public abstract class TheBase
    {
       protected int baseOne { get; set; }
       protected int baseTwo { get; set; }
       protected int baseThree { get; set; }
    }
    
    public class Derived : TheBase
    {
       public int Four { get; set; }
       public int Five { get; set; }
    
       public void SomeCode()
       {
           baseOne = 1;
           baseTwo = 2;
           baseThree = 3;
           Four = 4;
           Five = 5;
       }
    }
