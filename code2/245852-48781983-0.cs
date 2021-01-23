    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    class Program
    {
        public static int i = 0;
        public static string[] S = new string[] { "A", "B", "C", "D", "E", "F" };
        static void Main(string[] args)
        {
            
            Console.Write("Please Select : "+S[i]);
            ConsoleKeyInfo K = Console.ReadKey(); 
            while (K.Key.ToString() != "Enter")
            {
                Console.Write(ShowOptions(K));
                K = Console.ReadKey();
            }
            Console.WriteLine("");
            Console.WriteLine("Option Selected : " + S[i]);
            Console.ReadKey();
            }
        public static string ShowOptions(ConsoleKeyInfo Key)
        {
            
            if(Key.Key.ToString() == "UpArrow")
            {
                if (i != S.Length-1)
                    return "\b\b" + S[++i];
                else 
                    return "\b\b" + S[i];
            }
            else if (Key.Key.ToString() == "DownArrow")
            {
                if(i!=0)
                return "\b\b" + S[--i];
                else 
                    return "\b\b" + S[i];
            }
            return "";
        }
    }
    
    }
