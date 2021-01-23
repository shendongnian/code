    public static class MonadicArithmetic
    {
       public static Monad Take(int input) { return new Monad(input); }
       
       public class Monad
       {
          //Our value keeper is now a pure function that requires no external closures
          Func<Func<int>, int, int> operation;
          //and we add two new private fields; 
          //a hook to a lambda that will give us the result of all previous operations,
          Func<int> source;
          //... and the value for the current operation.
          private int addend;
    
          //our constructor now takes the value, stores it, and creates a simple lambda
          internal Monad(int input) { addend = input; operation = ()=>addend; }
          //and our private constructor now builds a new Monad from scratch
          private Monad(Func<int> prevOp, Func<Func<int>, int, int> currOp, int input) 
          { 
              source = prevOp, 
              operation = currOp, 
              addend = input; 
          }  
       
          //The methods will create new Monads that take the current Monad's value getter,   
          //keeping the current Monad in memory.
          public Monad Add(int input)
          { 
             return new Monad(this.Result, (f,i)=>f()+i, input); 
          }
          
          public Monad Subtract(int input)
          { 
             return new Monad(this.Result, (f,i)=>f()-i, input); 
          }
     
          //And we change our property to a method, so it can also 
          //be used internally as a delegate
          public int Result() { return operation(source, addend); }
       }
    }
    //usage
    var operations = MonadicArithmetic.Take(1).Add(3).Subtract(2); 
    //There are now 3 Monads in memory, each holding a hook to the previous Monad, 
    //the current addend, and a function to produce the result...
    ...
    //so that here, all the necessary pieces are still available.
    var result = operations.Result();  
