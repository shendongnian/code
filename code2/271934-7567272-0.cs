      public List<string> GetServerStatus()
       {
            List<string> cpuStatus = new List<string>();
            ObjectQuery wmicpus = new WqlObjectQuery("SELECT * FROM Win32_Processor");
            ManagementObjectSearcher cpus = new ManagementObjectSearcher(wmicpus);
            try
            {
                int coreCount = 0;
                int totusage = 0;               
                foreach (ManagementObject cpu in cpus.Get())
                {
                    //cpuStatus.Add(cpu["DeviceId"] + " = " + cpu["LoadPercentage"]);
                    coreCount += 1;
                    totusage += Convert.ToInt32(cpu["LoadPercentage"]);
                }
                if (coreCount > 1)
                {
                    double ActUtiFloat = totusage / coreCount;
                    int ActUti = Convert.ToInt32(Math.Round(ActUtiFloat));
                    //Utilisation = ActUti + "%";
                    cpuStatus.Add("CPU = " + ActUti);
                }
                else
                {
                    cpuStatus.Add("CPU = " + totusage);
                }
                            
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cpus.Dispose();
            }            
            return cpuStatus;
        }
