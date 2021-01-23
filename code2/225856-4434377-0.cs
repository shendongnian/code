    public static class MonadicArithmetic
    {
       public static Monad Take(int input) { return new Monad(input); }
       
       public class Monad
       {
          int theValue;
    
          internal Monad(int input) { theValue = input; }   
       
          public Monad Add(int input){ return new Monad(theValue + input); }
          public Monad Subtract(int input){ return new Monad(theValue - result); }
          public int Value { get { return theValue; } }
       }
    }
    
    ...
    
    //usage
    var result = MonadicArithmetic.Take(1).Add(2).Subtract(1).Value; //2
