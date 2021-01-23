    // delegate that will inform UI
    public delegate void FileProcessedHandler(string filePath, bool success);
    
    ...
    
    // Method that process files
    public void Process(FileProcessedHandler callback)
    {
    
       // loop processing file one by one
       for(..)
       {
          // process one file 
          var success = processFile(filePath);
    
          // Notify UI
          if (null != callback)
          {
             callback(filePath, success);
          }
       }
    }
