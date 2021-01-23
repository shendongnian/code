    private void populateListBox()
    {            
        List<string> tempListRecords = new List<string>();
        if (!FileUpload1.HasFile)
        {
            return;
        }
        using (StreamReader tempReader = new StreamReader(FileUpload1.FileContent))
        {
            string tempLine = string.Empty;
            while ((tempLine = tempReader.ReadLine()) != null)
            {
                // GET - line
                tempListRecords.Add(tempLine);
                // or do your coding.... 
            }
        }
    }
    
