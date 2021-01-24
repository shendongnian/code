    string input = "Fn.StartIf(some condition) \n\nBlock of blob text. This text could start with a new line or it may not... This text could be anything including numbers and special characters number like 123.\n\nand it multiple lines of text and could end with a new line or not. \n\nFn.EndIf";
    string pattern = @"(Fn\.StartIf\((.+?)\))([\S\s]+)(Fn\.EndIf)";
    Match match = Regex.Match(input, pattern);
    if (match != null)
    {
        for (int i = 1; i <= match.Groups.Count; i++)
        {
            Console.WriteLine($"Group #{i}: {match.Groups[i].Value}");
        }
    }
