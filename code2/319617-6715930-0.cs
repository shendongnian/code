    string text = "16/07/2011";
    Culture culture = ...; // The appropriate culture to use. Depends on situation.
    DateTime parsed;
    if (DateTime.TryParseExact(text, "dd/MM/yyyy", culture, DateTimeStyles.None,
                                out parsed))
    {
        for (int i = 1; i <= 3; i++)
        {
             Console.WriteLine(parsed.AddDays(-i).ToString("dd/MM/yyyy"));
        }
    }
    else    
    {
        // Handle bad input
    }
