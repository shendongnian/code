    class Program
    {
        static void Main(string[] args)
        {
            string rootLocation = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Telephony\Locations";
            getRegistryValues(rootLocation);
            Console.ReadLine();
        }
        public static void getRegistryValues(string rootLocation)
        {
            RegistryKey locationsKey =
            Registry.LocalMachine.OpenSubKey(rootLocation);
            if (locationsKey == null) return;
            string[] locations = locationsKey.GetSubKeyNames();
            Console.WriteLine(locations.Length.ToString());
            foreach (var location in locations)
            {
                Console.WriteLine(location.ToString());
                RegistryKey key = locationsKey.OpenSubKey(location);
                if (key == null) continue;
                foreach (string keyName in key.GetValueNames())
                {                  
                    if (keyName.Equals("Prefixes"))
                    {
                        string[] Prefixes = ((string[])(key.GetValue(keyName)));
                        Console.Write("Prefixes ");
                        foreach (string prefix in Prefixes)
                        {
                            Console.Write(prefix);
                        }
                       
                    }
                    else
                    {
                        Console.WriteLine(keyName + " {0}", key.GetValue(keyName));
                    }
                }
                
                getRegistryValues(rootLocation+@"\"+location);
              
                
            }
          
        }
