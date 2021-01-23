    using System;
    using System.Linq;
    
    class Sample {
        static void Main(){
            const char down = '-';
            
            Console.Write("Please enter a number! n[{0}]:", down);
            string input = Console.ReadLine();
            
            char ch = input.Last();
            int diff = (ch == down) ? -1 : 1;
            int val = Int32.Parse(input.TrimEnd(down));
            
            for(var i = 1; i <= 10; i++, val += diff)
                Console.WriteLine(val);
        }
    }
