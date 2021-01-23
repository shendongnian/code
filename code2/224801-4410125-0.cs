    using System;
 
    class Program {
        static void Main ()
        {
            Type t = Type.GetType ("Mono.Runtime");
            if (t != null)
                 Console.WriteLine ("You are running with the Mono VM");
            else
                 Console.WriteLine ("You are running something else");
        }
    }
