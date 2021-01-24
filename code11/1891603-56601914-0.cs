        static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ValidHD() != true)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static bool ValidHD()
        {
            string hdSN = String.Empty;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");
            foreach (ManagementObject wmi_HDD in moSearcher.Get())
            {
                hdSN = wmi_HDD["SerialNumber"].ToString();
            }
            if (hdSN == "Your_SN_Here")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
