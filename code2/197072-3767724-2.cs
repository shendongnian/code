     public void LogEntry(string msg, string path)
        {
            try
            {
           //It will open the file, append the your message and close the file             
            File.AppendAllText(path,msg);            
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
