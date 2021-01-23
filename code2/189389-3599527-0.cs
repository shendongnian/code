    using System; 
    
    namespace TestNullInts 
    { 
        class Program 
        { 
            static void Main(string[] args) 
            { 
                int? sum1 = 1; 
                int? sum2 = null; 
                int? sum3 = 3; 
    
                int total = 0; 
                total += (sum1 ?? 0) + (sum2 ?? 0) + (sum3 ?? 0); 
    
                Console.WriteLine(total); 
                Console.ReadLine(); 
            } 
        } 
    } 
