    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool a = false, b = false, c = false;
                bool[] d = new bool[] { a, b, c };
                System.Collections.BitArray e = new System.Collections.BitArray(d);
                if (Convert.ToBoolean(e.OfType<bool>().Any<bool>(condition => condition.Equals(true)) && e.OfType<bool>().Any<bool>(condition => condition.Equals(false)))) Console.WriteLine("some one is TRUE!.");
                if (Convert.ToBoolean(e.OfType<bool>().Any<bool>(condition => condition.Equals(true)) && e.OfType<bool>().Any<bool>(condition => condition.Equals(false)))) Console.WriteLine("some one is FALSE!.");
                if (Convert.ToBoolean(e.OfType<bool>().All<bool>(condition => condition.Equals(true)))) Console.WriteLine("All of them are TRUE!.");
                if (Convert.ToBoolean(e.OfType<bool>().All<bool>(condition => condition.Equals(false)))) Console.WriteLine("All of them are false!.");
                Console.ReadLine();
            }
        }
    }
