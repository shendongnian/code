    using System;
    using Microsoft.Win32;
    
    namespace colorChanger
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hello World");
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Console");
                regKey.SetValue("ColorTable10", 42495, RegistryValueKind.DWord);
                Console.ReadKey();
            }
        }
    }
