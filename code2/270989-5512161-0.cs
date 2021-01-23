    public string[] getFiles(string SourceFolder, string Filter, 
     System.IO.SearchOption searchOption)
    {
     
    ArrayList alFiles = new ArrayList();
         
     string[] MultipleFilters = Filter.Split('|');
          
     foreach (string FileFilter in MultipleFilters)
     {
           alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption));
     }
          
     return (string[])alFiles.ToArray(typeof(string));
    }
    public void button_click()
    {
    
    string[] sFiles = getFiles(Server.MapPath("~/"), 
     "*.gif|*.jpg|*.png|*.bmp|*.XL|*.PNG", 
     SearchOption.AllDirectories);
        
    foreach (string FileName in sFiles)
    {
     Response.Write(FileName + "<br />");
    }
    }
