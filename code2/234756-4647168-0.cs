    using System;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            SetConsoleCtrlHandler(ConsoleEventCallback, true);
            Console.ReadLine();
        }
    
        static bool ConsoleEventCallback(int eventType) {
            if (eventType == 2) {
                Console.WriteLine("Console window closing, death imminent");
            }
            return false;
        }
        // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    
    }
