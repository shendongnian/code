    public static class MonadicArithmetic
    {
       public static Monad Take(int input) { return new Monad(input); }
       
       public class Monad
       {
          //Change the "value keeper" into a Func that will return the value;
          Func<int> theValue;
    
          //the constructor now turns the input value into a lambda
          internal Monad(int input) { theValue = ()=>input; }
          //and another constructor is added for intra-class use that takes a lambda 
          private Monad(Func<int> input) { theValue = input; }   
       
          //And now the methods will create new lambdas that call the existing lambdas
          public Monad Add(int input){ return new Monad(()=>theValue() + input); }
          public Monad Subtract(int input){ return new Monad(()=>theValue() - input); }
          
          //Finally, our Value getter at the end will evaluate the lambda, unwrapping all the nested calls
          public int Value { get { return theValue(); } }
       }
    }
