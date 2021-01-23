    var reader = new StreamReader(path);
    try
    {
       // Do your work here
       reader.ReadToEnd();
    }
    catch (IOException ex)
    {
        // Handle specific error here
        ShowUserError(ex.Message);
    }
    catch (Exception ex)
    {
        // Handle general error here
        LogError(ex);
    }
    finally
    {
       // Perform clean up here
       // This code will run regardless if there was an error or not
       reader.Close();
    }
