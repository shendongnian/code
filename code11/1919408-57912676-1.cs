     using (var impersonator = new MyImpersonator())
     {
        string name = ConfigurationManager.AppSettings["name"];
        string password = ConfigurationManager.AppSettings["pass"];
                
        if (impersonator.LogOnCrossDomain(account, pass))
        {                   
             if (File.Exists(filepath))
             {                           
                 byte[] content = File.ReadAllBytes(filepath);                          
             }
         }  
      }
