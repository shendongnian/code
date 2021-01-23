            string pattern = @"z=\""(?<matcher>([a-z]{3,15}))\""";
            string input = @"z=""cat""";
            string replacement = @"<ANIMAL>${matcher}</ANIMAL>";
            string formattedOutput = Regex.Replace(input, pattern, replacement);
            Console.WriteLine(formattedOutput);
