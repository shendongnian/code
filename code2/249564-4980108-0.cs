    [WebMethod]
    public void ImportRates()
    {
        try
        {
           
         
            //HTTP Context to get access to the submitted data
            HttpContext postedContext = HttpContext.Current;
            //File Collection that was submitted with posted data
            HttpFileCollection Files = postedContext.Request.Files;
            //Make sure a file was posted
            string fileName =(string)postedContext.Request.Form["fileName"];
    
            MemoryStream memoryStream = new MemoryStream(fileArray);
    
    
        }
        catch (Exception ex1)
        {
            string error = string.Format("Error thrown for file {0} with {1} error.", fileName, ex);
    
        }
    }
