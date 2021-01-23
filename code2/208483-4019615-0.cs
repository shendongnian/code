    using System;      
    class Q      
    {   
        static void Main()    
        {
            string s = "using System;class Q{2}static void Main(){2}string s ={1}{0}{1};
            Console.Write(string.Format(s, s, (char)34, (char)123, (char)125));{3}{3}";             
            Console.Write(string.Format(s, s, (char)34, (char)123, (char)125));          
        }   
    } 
