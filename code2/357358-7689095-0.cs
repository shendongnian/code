    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
 
    namespace ConsoleApplication37 {
      public static class Program {
        static void Main(string[] args) {
          var numList=new[] {1, 3, 5, 6, 7, 8, 9, 10, 12};
          Console.WriteLine(numListToPossiblyDegenerateRanges(numList).Select(r => PrettyRange(r)).Intersperse(","));
        }
    
        /// <summary>
        /// e.g. 1,3,5,6,7,8,9,10,12
        /// becomes
        /// (1,1),(3,3),(5,10),(12,12)
        /// </summary>
        public static IEnumerable<Tuple<int,int>> numListToPossiblyDegenerateRanges(IEnumerable<int> numList) {
          Tuple<int, int> currentRange=null;
          foreach(var num in numList) {
            if(currentRange==null) {
              currentRange=Tuple.Create(num, num);
            } else if(currentRange.Item2==num-1) {
              currentRange=Tuple.Create(currentRange.Item1, num);
            } else {
              yield return currentRange;
              currentRange=Tuple.Create(num, num);
            }
          }
          if(currentRange!=null) {
            yield return currentRange;
          }
        }
    
        /// <summary>
        /// e.g. (1,1) becomes "1"
        /// (1,3) becomes "1-3"
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static string PrettyRange(Tuple<int,int> range) {
          if(range.Item1==range.Item2) {
            return range.Item1.ToString();
          }
          return string.Format("{0}-{1}", range.Item1, range.Item2);
        }
    
        public static string Intersperse(this IEnumerable<string> items, string interspersand) {
          var currentInterspersand="";
          var result=new StringBuilder();
          foreach(var item in items) {
            result.Append(currentInterspersand);
            result.Append(item);
            currentInterspersand=interspersand;
          }
          return result.ToString();
        }
      }
    }
   
