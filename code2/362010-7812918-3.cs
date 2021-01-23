     private static void Main(string[] args)
        {
    
            string[] subkeynames = Registry.LocalMachine.GetSubKeyNames();
            Console.Out.WriteLine(Registry.LocalMachine.Name);
    
            foreach (string subkey in subkeynames)
            {
                try
                {
                    //this might raise a security exception
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey(subkey);
                    recurse(rk);
                    rk.Close();
                }
                catch (Exception e)
                {
                    Console.Write("Couldnt access key : " + subkey + "\n " + e.ToString());
                }
            }
    
            Console.ReadKey();
        }
    
        private static void recurse(RegistryKey rk)
        {
            Console.WriteLine(rk.Name);
            string[] subkeys = rk.GetSubKeyNames();
    
            if (null != subkeys && subkeys.Count() > 0)
            {
                foreach (var subkey in subkeys)
                {
                    try
                    {
                        //this might raise a security exception
                        RegistryKey key = rk.OpenSubKey(subkey);
                        recurse(key);
                    }
                    catch (Exception e)
                    {
                        Console.Write("Couldnt access key : " + subkey + "\n " + e.ToString());
                    }
    
                }
            }
        }
