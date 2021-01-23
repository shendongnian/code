    string originalstring = "codename123";
    string alphabets = string.empty;
    string numbers = string.empty;
    foreach (char item in mainstring)
    {
       if (Char.IsLetter(item))
       alphabets += item;
       if (Char.IsNumber(item))
       numbers += item;
    }
