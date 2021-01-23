    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ConsoleApplication12 {
      public class Program {
        public static void Main(string[] args) {
          const int N=100;
    
          int sum;
          try {
            sum=A().Aggregate((self, next) => {
              if(self+next<=N)
                return self+next;
              else
                throw new ResultException(self);
            });
          } catch(ResultException re) {
            sum=re.Value;
          }
          Debug.Print("Sum="+sum);
        }
    
        private class ResultException : Exception {
          public readonly int Value;
    
          public ResultException(int value) {
            Value=value;
          }
        }
    
        private static IEnumerable<int> A() {
          var i=0;
          while(true) {
            yield return i++;
          }
        }
      }
    }
    
