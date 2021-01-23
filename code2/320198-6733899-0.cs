    string num = "123x";
    
    foreach (char c in num.ToArray())
    {
        if (!Char.IsDigit(c))
        {
            Console.WriteLine("character " + c + " is not a number");
            return;
        }
    }
