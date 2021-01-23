    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    
    [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);
         
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
            }
        }
    }
