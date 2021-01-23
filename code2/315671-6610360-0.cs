    using System;
     
    class Program
    {
        static void Main()
        {
            string s = "verkoop test [Hot News] [Smurf]";
            int i = s.IndexOf('[');
            if(i > -1)
            {
                Console.WriteLine(s.Substring(0, i));
                Console.WriteLine(s.Substring(i));
            }
        }
    }
