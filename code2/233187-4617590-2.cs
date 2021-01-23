    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
    
    namespace Craft
    {
        class Act
        {
            static void Main(string[] args)
            {
                
                var a = new List<string>
                    { "I", "Love", "You", "More", "Today", "Than", "Yesterday" };
    
                var tx = a.SplitByCondition(s => s == "More");
    
                foreach (var s in tx.Item1)
                    Console.WriteLine("First Half : {0}", s);
    
                foreach (var s in tx.Item2)
                    Console.WriteLine("Second Half : {0}", s);
    
                Console.ReadLine();                    
            }
        
        }//Act
    
        public static class Helper
        {
           
            public static Tuple<List<T>, List<T>> SplitByCondition<T>
                (this IEnumerable<T> t, Func<T, bool> terminator)
            {
    
    
                var tx = new Tuple<List<T>, List<T>>
                              (new List<T>(), new List<T>()); 
    
                var iter = t.GetEnumerator();
    
                while (iter.MoveNext())
                {
                    if (terminator(iter.Current))
                    {
                        tx.Item2.Add(iter.Current);
                        break;
                    }
    
                    tx.Item1.Add(iter.Current);
                }
    
                while (iter.MoveNext())
                    tx.Item2.Add(iter.Current);
    
                return tx;
            }      
        
        }//Helper
    }//Craft
