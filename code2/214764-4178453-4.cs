    using System;
    using System.Runtime.InteropServices;
    
    namespace CsharpApp
    {
        class Program
        {
            // I added DelphiLibrary.dll to my project (NOT in References, but 
            // "Add existing file"). In Properties for the dll, I set "BuildAction" 
            // to None, and "Copy to Output Directory" to "Copy always".
            // Make sure your Delphi dll has version information included.
    
            [DllImport("DelphiLibrary.dll", 
                       CallingConvention = CallingConvention.StdCall, 
                       CharSet = CharSet.Ansi)]
            public static extern bool 
                DelphiFunction(int inputInt, string inputString,
                               out int outputInt,
                               int outputStringBufferSize, ref string outputStringBuffer,
                               int errorMsgBufferSize, ref string errorMsgBuffer);
    
            static void Main(string[] args)
            {
                int inputInt = 1;
                string inputString = "This is a test";
                int outputInt;
                const int stringBufferSize = 1024;
                var outputStringBuffer = new String('\x00', stringBufferSize);
                var errorMsgBuffer = new String('\x00', stringBufferSize);
    
                if (!DelphiFunction(inputInt, inputString, 
                                    out outputInt,
                                    stringBufferSize, ref outputStringBuffer,
                                    stringBufferSize, ref errorMsgBuffer))
                    Console.WriteLine("Error = \"{0}\"", errorMsgBuffer);
                else
                    Console.WriteLine("outputInt = {0}, outputString = \"{1}\"",
                                      outputInt, outputStringBuffer);
    
                Console.Write("Press Enter:");
                Console.ReadLine();
            }
        }
    }
