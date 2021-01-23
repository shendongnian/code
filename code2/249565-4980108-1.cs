    [WebMethod]
    public void ImportRates()
    {
        try
        {
           
         
            //HTTP Context to get access to the submitted data
            HttpContext postedContext = HttpContext.Current;
            //File Collection that was submitted with posted data
            HttpFileCollection files = postedContext.Request.Files;
            //Make sure a file was posted
            string fileName =files[0].FileName;
    
            MemoryStream memoryStream = new MemoryStream(files[0].InputStream);
    
    
        }
        catch (Exception ex1)
        {
            string error = string.Format("Error thrown for file {0} with {1} error.", fileName, ex);
    
        }
    }
