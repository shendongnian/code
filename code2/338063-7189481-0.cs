    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestMaybe
    {
        class Program
        {
            static void Main(string[] args)
            {
                var strings = new string[] { "1", "2", "notint", "3" };
                var ints = strings.Select(s => new Maybe<string, int>(s, str => int.Parse(str))).Where(m => !m.nothing).Select(m => m.value);
                foreach (var i in ints)
                {
                    Console.WriteLine(i);
                }
                Console.ReadLine();
    
            }
        }
    
        public class Maybe<T1, T2>
        {
            public readonly bool nothing;
            public readonly T2 value;
    
            public Maybe(T1 input, Func<T1, T2> map)
            {
                try
                {
                    value = map(input);
                }
                catch (Exception)
                {
                    nothing = true;
                }            
            }
        }
    }
    
