    static void Main(string[] args)
    {
            string keyPath = "SOFTWARE\\Apps";
            var subKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(keyPath, true); // This method accepts the RegistryView parameter.
            if (subKey != null)
            {
                subKey.DeleteSubKey("Application");
                Console.WriteLine("DELETED");
            }
            else
            {
                Console.WriteLine("NOT FOUND");
            }
    }
