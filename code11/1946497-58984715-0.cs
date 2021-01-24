    using Newtonsoft.Json;
    using System;
    
    namespace ConsoleApp3
    {
    class Program
    {
        static void Main(string[] args)
        {
            decimal inputvalue = 38.1439743m;
    
            numericvalues n = new numericvalues();
            n.value = inputvalue;
    
            string serialized = JsonConvert.SerializeObject(n); // produces "38.143974300000004" <- incorrect
    
            Console.WriteLine(inputvalue);
            Console.WriteLine(serialized);
            Console.ReadKey();
        }
    
        public class numericvalues
        {
            public decimal value { get; set; }
        }
    }
    }
