    try
    {
        var fileInfo = new FileInfo(path);
    }
    catch (System.IO.PathTooLongException ex)
    {
        handleError(ex);
    }
    catch (System.ArgumentException ex)
    {
       handleError(ex);
    }
    catch (System.UnauthorizedAccessException ex)
    {
    }
    catch (System.SecurityException ex)
    {
       handleError(ex);
    }
    
    public void handleError(Exception ex)
    {
        //do some stuff
    }
