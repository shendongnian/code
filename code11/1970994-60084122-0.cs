     public class Solver {
       static Dictionary<long, long> s_Sums = new Dictionary<long, long>();
       private static void Build() {
         long total = 0;
         for (long i = 0; i <= 77936; ++i) {
           total += i * i * i;
           s_Sums.Add(total, i);
         }
       } 
       static Solver() 
         Build(); 
       }
  
       public static long findNb(long m) {
         return s_Sums.TryGetValue(m, out long result) 
           ? result 
           : -1;
       }
     }
