    string var = "Hello345wor705Ld";
    string alpha = string.Empty;
    string numer = string.Empty;
    foreach (char str in var)
    {
        if (char.IsDigit(str))
            numer += str.ToString();
        else
            alpha += str.ToString();
    }
    Console.WriteLine("String is: " + alpha);
    Console.WriteLine("Numeric character is: " + numer);
    Console.Read();
