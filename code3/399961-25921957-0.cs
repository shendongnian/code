    void RenameFile(string from, string to)
    {
        
         try
        
         {   
    
                System.IO.File.Move(from, to)       
         }   
         catch    
         {  
                System.Threading.Thread.Sleep(500);      
                RenameFile(from, to);
         }   
    }
    
