    var source = "RUOKICU4T";
    var builder = new StringBuilder(source.Length);
    for (int index = 0; index < builder.Length; index += 1)
    {
        if (Char.IsDigit(source[index]))
        {
            builder[index] = GetRandomDigit();
        }
        else if (Char.IsLetter(source[index]))
        {
            builder[index] = GetRandomLetter();
        }
    }
    string result = builder.ToString();
