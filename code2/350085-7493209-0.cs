    String[] split = tempString.Split('~');
    try
    {
        typeOfVehicle = split[0];
        manufactuer = split[1];
    }
    catch
    {
        Console.WriteLine("Oops! It didn't work.");
        Console.WriteLine("The offending string was \"{0}\"", tempString);
    }
