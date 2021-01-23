    #define TRACE_ON
    using System;
    using System.Diagnostics;
    public class Trace 
    {
        [Conditional("TRACE_ON")]
        public static void Msg(string msg)
        {
            Console.WriteLine(msg);
        }
    }  
    public class ProgramClass
    {
        static void Main()
        {
            Trace.Msg("Now in Main...");
            Console.WriteLine("Done.");
        }
    }
