    using (var input = new StreamReader("input.txt"))
    {
        var currentLine = 0;
        while (!input.EndOfStream)
        {
            var line = input.ReadLine() ?? "";
            if (++currentLine == 1)
            {
                // first line is upper case
                Console.WriteLine(line.ToUpper());
            }
            else
            {
                // Every word longer than 3 letter starts with capitalized
                Console.WriteLine(Regex.Replace(line, @"\w{3,}", 
                    (match) => CultureInfo.CurrentCulture
                        .TextInfo.ToTitleCase(match.Value.ToLower())));
            }
        }
    }
