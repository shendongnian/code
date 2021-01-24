    try
    {
        // Incrementing by 5 to save time. We can use `++` to cover all possible values
        // but it will take a long time to execute.
        for (int a = 0; a <= 255; a += 5)
            for (int r = 0; r <= 255; r += 5)
                for (int g = 0; g <= 255; g += 5)
                    for (int b = 0; b <= 255; b += 5)
                        ColorTranslator.FromHtml($"#{a.ToString("X2")}{r.ToString("X2")}" +
                                                 $"{g.ToString("X2")}{b.ToString("X2")}");
        Console.WriteLine("All is good!");
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Failed. Message='{ex.Message}'");
    }
