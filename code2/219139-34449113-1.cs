    try
    {
        throw new CustomException { Severity = 100 };
    }
    catch (CustomException ex)
    {
       if (ex.Severity > 50)
        {
           Console.WriteLine("*BING BING* WARNING *BING BING*");
        }
       else
        {
           Console.WriteLine("Whooops!");
        }
    }
