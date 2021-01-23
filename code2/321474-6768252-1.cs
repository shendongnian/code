    using System;
    using System.Collections.Generic;
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            var myTypes = new MyType[3];
            myTypes[0] = new MyType();
            myTypes[1] = new MyType();
            myTypes[2] = new MyType();
            for (var current = 0; current < myTypes.Length; ++current)
            {
                // here you customize what goes where
                myTypes[current].Values.Add("a", current);
                myTypes[current].Values.Add("b", "myBvalue");
                myTypes[current].Values.Add("c", (ushort)current);
            }
            foreach (var current in myTypes)
            {
                Console.WriteLine(
                   string.Format("A={0}, B={1}, C={2}", 
                                  current.Values["a"], 
                                  current.Values["b"],
                                  current.Values["c"]));
            }
        }
    }
