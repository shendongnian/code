    void InstallPrimaryInteropAssemblies()
        {
            try
            {
                string str = "path\o2007pia.msi";
                System.Diagnostics.Process process = new System.Diagnostics.Process
                {
                    StartInfo = { FileName = str }
                };
                process.Start();
                while (!process.HasExited)
                {
                    System.Threading.Thread.Sleep(0x3e8);
                }
            }
            catch (Exception exception)
            {
            }
        }
