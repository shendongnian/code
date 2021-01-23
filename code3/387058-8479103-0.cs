    int read;
    try
    {
        read = readHandler.EndReceive(ar);
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine(ex.ToString()); //ADD BREAKPOINT HERE
    }
