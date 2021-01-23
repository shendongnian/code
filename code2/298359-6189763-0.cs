    try
    {
        File.WriteAllText(filePath, contents);
    }
    catch (SecurityException ex)
    {
        //present dialog
    }
    catch (Exception ex)
    {
        //All other exceptions handled the same
    } 
