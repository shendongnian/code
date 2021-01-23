    try
    {
        throw new CustomException { Severity = 100 };
    }
    catch (CustomException ex) when (ex.Severity > 50)
    {
        Console.WriteLine("*BING BING* WARNING *BING BING*");
    }
    catch (CustomException ex)
    {
        Console.WriteLine("Whooops!");
    }
