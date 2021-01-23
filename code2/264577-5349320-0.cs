    try
    {
        if user name is exit
        {
            throw new Exception("The Username Already Exist");
        }
        if e-mail is already exit
        {
            throw new Exception("The E-Mail Already Exist");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("The Error is{0}", ex.Message);
    }
