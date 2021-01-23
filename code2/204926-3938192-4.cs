    using System;
    using System.Collections.Generic;
    using System.Linq;
    class abc<T>  {
        Func<IEnumerable<T>,IEnumerable<T>> sorter;
        public abc(Func<IEnumerable<T>,IEnumerable<T>> sorter) {
            this.sorter=sorter ?? (x=>x);
        }
        public void someMethod(IEnumerable<T> src, bool afterSort = false) {
            var res= (afterSort?sorter:x=>x) (src.Skip(5).Take(10));
  
            Console.WriteLine(string.Join(", ",res.Select(el=>el.ToString()).ToArray()));
        }
    }
    public class Program {
        static void Main()    {
            var strs = Enumerable.Range(0,1000).Select(i=>i.ToString());
            var myAbc = new abc<string>(
                xs=>xs.OrderByDescending(x=>x.Length).ThenByDescending(x=>x.Substring(1))
            );
            myAbc.someMethod(strs);      //5, 6, 7, 8, 9, 10, 11, 12, 13, 14
            myAbc.someMethod(strs,true); //14, 13, 12, 11, 10, 5, 6, 7, 8, 9
        }
    }
