    for (int i = 1; i <= 4; i++)
    {
        try
        {
            MyDevice.SetGpo(i, false);
        }
        catch (NotImplementedException ex)
        {
            Console.WriteLine(ex.Message); // set your breakpoint here
            throw ex;
        }
    }
