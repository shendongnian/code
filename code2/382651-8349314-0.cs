    using System;
    using System.Collections.Generic;
    
    public class Program
    {
        static void Main(string[] args)
        {
            var empty = Empty();
            Console.WriteLine(empty is IDisposable); // Prints True
        }
        
        static IEnumerable<string> Empty()
        {
            yield break;
        }
    }
