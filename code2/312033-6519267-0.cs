    public class UebersichtRepository 
    {
       
        public string GetInfo()
        {
            string result = null;
    
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");               
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    result = queryObj["Manufacturer"].ToString();
                }
            return result;            
        }
    }
