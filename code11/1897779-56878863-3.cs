    try
    {
       double x = 1 / 0.0;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    } 
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
