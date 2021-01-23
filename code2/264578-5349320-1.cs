    try
    {
        if (username exists)
        {
            throw new Exception("The Username Already Exist");
        }
        if (e-mail exists)
        {
            throw new Exception("The E-Mail Already Exist");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("The Error is{0}", ex.Message);
    }
