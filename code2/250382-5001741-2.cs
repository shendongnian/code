    public List<string> Example    
    {     
       get 
       {   
          ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher("root\\WMI", 
              "SELECT * FROM MSStorageDriver_FailurePredictStatus");        
          List<string> output = new List<string>();        
          foreach (ManagementObject queryObj in searcher.Get())
              output.Add(System.Convert.ToString(queryObj["InstanceName"]));  
          return output;
       }            
    }
