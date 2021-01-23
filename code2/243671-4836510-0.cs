    private static Thread oThread = new Thread(new ParameterizedThreadStart(delete));
    
    ...
    
    ((DocumentEvents_Event)document).Close += DocumentClose;
    
    ...
    
    
    private static void DocumentClose()
    {
          oThread.Start(path);
    }
    
    static void delete(object path)
    {
        try
        {
            File.Delete((string)path);
        }
        catch (Exception)
        {
            Thread.Sleep(500);
            delete(path);
        }
    }
