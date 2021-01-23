    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication33 {
      public static class Program {
        private static void Main() {
          var result1=DoTheCSharpOperation(Operator.Plus, 1.2, 2.4);
          var result2=DoTheCSharpOperation(Operator.Plus, "Hello", 2.4);
          var result3=DoTheCSharpOperation(Operator.Minus, 5, 2); 
         
          Debug.WriteLine(result1); //a double with value 3.6
          Debug.WriteLine(result2); //a string with value "Hello2.4"
          Debug.WriteLine(result3); //an int with value 3
        }
    
        public enum Operator {
          Plus,
          Minus
        }
    
        public static object DoTheCSharpOperation(Operator op, dynamic a, dynamic b) {
          switch(op) {
            case Operator.Plus:
              return a+b;
            case Operator.Minus:
              return a-b;
            default:
              throw new Exception("unknown operator "+op);
          }
        }
      }
    }
    
