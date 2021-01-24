    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Test1
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                string str = "20-54 Jackson Avenue Date) Brooklyn, NY 11352";
                string[] result =Regex.Matches(str, "[a-zA-Z0-9-]+[^!@#$%^&*(),.?\":{}|<>,\\d{5}]*").Cast<Match>().Select(x=>x.Value).ToArray();
                Console.WriteLine("Address:"+result[0].Trim());
                Console.WriteLine("City:"+result[1].Trim());
                Console.WriteLine("State:"+result[2].Trim());
                Console.WriteLine("Zip Code:"+result[3].Trim());
                Console.ReadLine();
            }
        }
    }
