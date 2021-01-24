    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp8
    {
        public static class EnumExtension
        {
            class OnceEnumerable<T> : IEnumerable<T>
            {
                IEnumerable<T> col;
                bool hasBeenEnumerated = false;
                public OnceEnumerable(IEnumerable<T> col)
                {
                    this.col = col;
                }
    
                public IEnumerator<T> GetEnumerator()
                {
                    if (hasBeenEnumerated)
                    {
                        throw new InvalidOperationException("This collection has already been enumerated.");
                    }
                    this.hasBeenEnumerated = true;
                    return col.GetEnumerator();
                }
    
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }
    
            public static IEnumerable<T> OnlyOnce<T>(this IEnumerable<T> col)
            {
                return new OnceEnumerable<T>(col);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                 var col = Enumerable.Range(1, 10).OnlyOnce();
 
                 var colCount = col.Count(); //first enumeration
                 foreach (var c in col) //second enumeration
                 {
                     Console.WriteLine(c);
                 }
            }
        }
    }
