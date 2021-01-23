     public static class MyClass
        {
            public static void Main()
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
                foreach (ManagementObject mo in mos.Get())
                {
                    Console.WriteLine(mo["Name"]);
                }
    
    
            }
        }
