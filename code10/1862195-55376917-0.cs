    //...
    if (sodas[i] == null)
        Console.WriteLine("Det är tomt på indexet: {0}!", i + 1)
    else if (!String.Equals(sodas[i], name, StringComparison.OrdinalIgnoreCase))
        Console.WriteLine("Drycken hittades inte på indexet: {0}.", i + 1);
    else //Another if is unnecessary
    {
        //...
    }
    //...
