    double DbyZ(double numerator)
    {
        try 
        {
            return numerator / 0.0;
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine("Invalid operation");
        }
    } 
    ...
    try
    {
         DbyZ(1.0);
    }
    catch(Exception ex)
    {
        Console.WriteLine("Exception");
    }
