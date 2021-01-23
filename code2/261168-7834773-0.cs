    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MachineGUID:" + MachineGUID);
            Console.ReadKey();
        }
        public static string MachineGUID
        {
            get
            {
                Guid guidMachineGUID;
                if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography") != null)
                {
                    if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography").GetValue("MachineGuid") != null)
                    {
                        guidMachineGUID = new Guid(Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography").GetValue("MachineGuid").ToString());
                        return guidMachineGUID.ToString();
                    }
                }
                return null;
            }
        }
    }
