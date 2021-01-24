    string input = @"This is text
        i want
        to keep
            but
        Replace this sentence
        because i dont like it.";
    string dontLike = @"Replace this sentence because i dont like it.";
    string pattern = Regex.Escape(dontLike).Replace(@"\ ", @"\s+");
    Console.WriteLine("Pattern:");
    Console.WriteLine(pattern);
    string clean = Regex.Replace(input, pattern, "");
    Console.WriteLine();
    Console.WriteLine("Result:");
    Console.WriteLine(clean);
    Console.ReadKey();
