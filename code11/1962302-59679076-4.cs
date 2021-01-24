    var builder = new StringBuilder();
    foreach(var character in input)
    {
       if (!char.IsWhiteSpace(character))
       {
          builder.Append(character);
       }
    }
    return builder.ToString();
