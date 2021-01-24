    using System;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input;
                string output;
                MyStr aString = new MyStr();
                Console.WriteLine("enter a string");
               input = Console.ReadLine();
                output = aString.reverseStr(input);
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    class MyStr
    {
        public string reverseStr(string Myname)
        {
            char[] arr = Myname.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
    }
