    using Microsoft.Win32;
    using System;
    class hi
    {
        public static void Main()
    {
        String subKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
        RegistryKey key = Registry.LocalMachine;
        RegistryKey skey = key.OpenSubKey(subKey);
        Console.WriteLine("OS Name: {0}", skey.GetValue("ProductName"));
    }
    }
    
    
    hope so this one is useful 
    getting this way from somewhere
