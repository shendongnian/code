    using System;
    
    namespace TestTuple
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var mytuple = new Tuple<string, string, DateTime>("Alexander", "Moor", Convert.ToDateTime("12.03.2009"));
                Console.WriteLine("{1},{0} born {2}", mytuple.Item1, mytuple.Item2, mytuple.Item3);
            }
        }
    }
