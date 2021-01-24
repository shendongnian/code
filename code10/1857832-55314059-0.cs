    public List<string> SaveAvroBytesOnFile(EventData eventHubMessage, string functionAppDirectory)
        {
            try
            {                
                string fileName = "avro-bytes.avro";
                List<string> filesToProcess = new List<string>();
                string singleFileNameToSave = fileName;
                filesToProcess.Add(singleFileNameToSave);              
                string path = Path.Combine(functionAppDirectory,"AvroBytesFiles");  
                System.IO.Directory.CreateDirectory(path);              
                File.WriteAllBytes($"{path}{singleFileNameToSave}", eventHubMessage.GetBytes());                
                return filesToProcess;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
