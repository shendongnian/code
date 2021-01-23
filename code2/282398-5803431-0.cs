     public bool CheckFileType(string FileName)
     {
        bool result = false ;
        
        try
         {
          string Ext = Path.GetExtension(FileName);
          switch (Ext.ToLower())
          {
            case ".gif":                   
            case ".JPEG":                    
            case ".jpg":                  
            case ".png":                   
            case ".bmp":                   
                result = true;
                break;
           }
          }catch(Exception e)
          {
             // Log exception 
          }
          return result;
         }
         
