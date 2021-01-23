    var input = "The quick brown fox jumps over the lazy dog.";
    var charCount = 0;
    var maxLineLength = 11;
    var lines = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .GroupBy(w => (charCount += w.Length + 1) / maxLineLength)
        .Select(g => string.Join(" ", g));
    // That's all :)
    foreach (var line in lines) {
        Console.WriteLine(line);
    }
