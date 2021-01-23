    class Program
    {
        static void Main(string[] args)
        {
            DirectoryEntry rootDse = new DirectoryEntry("LDAP://rootDSE");
            DirectoryEntry root = new DirectoryEntry("GC://" + rootDse.Properties["defaultNamingContext"].Value.ToString());
            DirectorySearcher searcher = new DirectorySearcher(root);
            searcher.Filter = "(objectClass=groupPolicyContainer)";
            foreach (SearchResult gpo in searcher.FindAll())
            {
                var gpoDesc = gpo.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString();
                Console.WriteLine($"GPO: {gpoDesc}");
                DirectoryEntry gpoObject = new DirectoryEntry($"LDAP://{gpoDesc}");
                try
                {
                    Console.WriteLine($"DisplayName: {gpoObject.Properties["displayName"].Value.ToString()}");
                }
                catch
                {
                }
                try
                {
                    Console.WriteLine($"PCFileSysPath: {gpoObject.Properties["gPCFileSysPath"].Value.ToString()}");
                }
                catch
                {
                }
                try
                {
                    Console.WriteLine($"VersionNumber: {gpoObject.Properties["versionNumber"].Value.ToString()}");
                }
                catch
                {
                }
                try
                {
                    Console.WriteLine($"UserExtensionNames: {gpoObject.Properties["gPCUserExtensionNames"].Value.ToString()}");
                }
                catch
                {
                }
                try
                {
                    Console.WriteLine($"MachineExtensionNames: {gpoObject.Properties["gPCMachineExtensionNames"].Value.ToString()}");
                }
                catch
                {
                }
                try
                {
                    Console.WriteLine($"PCFunctionality: {gpoObject.Properties["gPCFunctionalityVersion"].Value.ToString()}");
                }
                catch
                {
                }
            }
            Console.ReadKey();
        }
    }
