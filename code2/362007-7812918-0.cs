    private static void Main(string[] args)
            {
    
                string[] subkeynames = Registry. LocalMachine. GetSubKeyNames();
                Console.Out.WriteLine(Registry.LocalMachine.Name);
    
                foreach (string subkey in subkeynames)
                {
                   RegistryKey rk = Registry.LocalMachine.OpenSubKey(subkey);
                   recurse(rk);
                }
    
                Console.ReadKey();
            }
    
         private static void recurse(RegistryKey rk)
        {
            Console.WriteLine(rk.Name);
            string[] subkeys = rk.GetSubKeyNames();
            
            if(null != subkeys && subkeys.Count() > 0)
            foreach (var subkey in subkeys)
            {
                RegistryKey key = rk.OpenSubKey(subkey);
                recurse( key);
            }
            
            
        }
