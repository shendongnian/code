        public void Main()
        {
            string[] sourceFiles = Directory.GetFiles(Dts.Variables["Y:\\Monoday\\Rachael\\PromasterFiles\\Partners YTD Promaster Monthly Transaction list.xlsx"].Value.ToString()); 
            DateTime lastDate = new DateTime(2011, 7, 1);
            Boolean runPackage = false;
            foreach (string currentFile in sourceFiles)             
            {                                  
                DateTime lastModifyDate = File.GetLastWriteTimeUtc(currentFile);                                                  
                if (lastModifyDate > lastDate)                 
                {                                        
                    lastDate = lastModifyDate; 
                    runPackage = true;                 
                }             
            }   
           
        }
    
