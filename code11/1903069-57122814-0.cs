    Planets result;
    bool success = Enum.TryParse<Planets>("Mars", true, out result);
    if(success){
        Console.Write((int)result);
    } else {
        Console.Write("no match");
    }
