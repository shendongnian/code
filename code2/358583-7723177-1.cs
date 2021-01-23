            string pattern = @"z=\""(?<WHATEVER>([a-z]{3,15}))\""";
            string input = @"z=""cat""";
            string replacement = @"<ANIMAL>${WHATEVER}</ANIMAL>";
            string formattedOutput = Regex.Replace(input, pattern, replacement);
            Console.WriteLine(formattedOutput);
