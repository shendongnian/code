    public string ReadResourceValue(string file, string key)
    {
        
        string resourceValue = string.Empty;
        try
        {
           
            string resourceFile = file;
            
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
           
            ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(resourceFile, filePath, null);
            // retrieve the value of the specified key
            resourceValue = resourceManager.GetString(key);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            resourceValue = string.Empty;
        }
        return resourceValue;
    }
