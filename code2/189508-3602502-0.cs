    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    
    namespace ConsoleApplication1
    {
        static class Extensions
        {
            public static TOutput[] ToArray<TSource, TOutput>(this IEnumerable<TSource> col, Converter<TSource, TOutput> converter)
            {
                return Array.ConvertAll<TSource, TOutput>(col.ToArray(), converter);
            }
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                string original = "5.0.0.0";
                int[] tmp = original.Split('.').ToArray<string, int>(new Converter<string, int>(delegate(string s)
                {
                    int result;
                    return int.TryParse(s, out result) ? result : 0;
                }));
    
                tmp[tmp.Length - 1]++;
                // re should contain 5.0.0.1
                string re = String.Join(".", tmp);
            }
        }
    }
