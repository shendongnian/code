    try
    {
        //Declare your streamwriter
        StreamWriter sw = new StreamWriter(Initialization);
    }
    catch
    {
        //Handle the errors
    }
    finally
    {
        sw.Dispose();
    }
