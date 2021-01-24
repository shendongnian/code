    string authorsFile = "file.xlsx";
    
    try
    {
        if (File.Exists(Path.Combine(rootFolder, authorsFile)))
        {
            File.Delete(Path.Combine(rootFolder, authorsFile));
        }
        //nothing   
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
