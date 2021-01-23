    using System;
    using System.Runtime.InteropServices;
    
    namespace fpuconsole
    {
        class Program
        {
            [DllImport("msvcrt.dll", EntryPoint = "_controlfp_s")]
            public static extern int ControlFPS(UIntPtr currentControl, 
                uint newControl, uint mask);
    
            public const int MCW_DN= 0x03000000;
            public const int _DN_SAVE = 0x00000000;
            public const int _DN_FLUSH = 0x01000000;
    
            static void PrintLog10()
            {
                //Display original values
                Console.WriteLine("_controlfp_s Denormal Control untouched");
                Console.WriteLine("\tdouble.Epsilon = {0}", double.Epsilon);
                Console.WriteLine("\tMath.Log10(double.Epsilon) = {0}",
                    Math.Log10(double.Epsilon));
                Console.WriteLine("");
    
                //Set Denormal to Save, calculate Math.Log10(double.Epsilon)
                var controlWord = new UIntPtr();
                var err = ControlFPS(controlWord, _DN_SAVE, MCW_DN);
                if (err != 0)
                {
                    Console.WriteLine("Error setting _controlfp_s: {0}", err);
                    return;
                }
                Console.WriteLine("_controlfp_s Denormal Control set to SAVE");
                Console.WriteLine("\tdouble.Epsilon = {0}", double.Epsilon);
                Console.WriteLine("\tMath.Log10(double.Epsilon) = {0}", 
                    Math.Log10(double.Epsilon));
                Console.WriteLine("");
                
                //Set Denormal to Flush, calculate Math.Log10(double.Epsilon)
                err = ControlFPS(controlWord, _DN_FLUSH, MCW_DN);
                if (err != 0)
                {
                    Console.WriteLine("Error setting _controlfp_s: {0}", err);
                    return;
                }
                Console.WriteLine("_controlfp_s Denormal Control set to FLUSH");
                Console.WriteLine("\tdouble.Epsilon = {0}", double.Epsilon);
                Console.WriteLine("\tMath.Log10(double.Epsilon) = {0}", 
                    Math.Log10(double.Epsilon));
                Console.WriteLine("");
            }
    
            static void Main(string[] args)
            {
                PrintLog10();
            }
        }
    }
