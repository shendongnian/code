    string FILE_NAME = "Log" + System.DateTime.Now.Ticks.ToString() + "." + "txt"; 
    string str_Path = HostingEnvironment.ApplicationPhysicalPath + ("Log") + "\\" +FILE_NAME;
   
     if (!File.Exists(str_Path))
     {
         File.Create(str_Path).Close();
        File.AppendAllText(str_Path, jsonStream + Environment.NewLine);
        
     }
     else if (File.Exists(str_Path))
     {
        
         File.AppendAllText(str_Path, jsonStream + Environment.NewLine);
         
     }
