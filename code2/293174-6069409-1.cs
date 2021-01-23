    DateTime dt;
    if (DateTime.TryParse("9/10/2011 9:20:45 AM", out dt))
    {
        Console.WriteLine(dt.ToString("dd/MM/yyyy hh:mm:ss tt"));
    }
    else
    {
        Console.WriteLine("Error while parsing the date");
    }
