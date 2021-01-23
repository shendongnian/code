    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication2
    {
     
        public struct AStruct
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string fn; 
        }
    
    
        class Program
        {
            [DllImport("OneEntryPoint", CallingConvention = CallingConvention.Cdecl)]
             static extern void AnEntry(AStruct somestruct); 
    
    
            static void Main(string[] args)
            {
                try
                {
                    AStruct fred;
                    fred.fn = "hello world";
                    Program.AnEntry(fred);
                    Console.WriteLine("Done");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
