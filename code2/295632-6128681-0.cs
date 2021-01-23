    var regex = new Regex(@"^\[(\d{2}:\d{2}:\d{2})\]\s*(\[(System|Warn)[\w\s]*\])?\s*<([^>]*)>\s*(.*)$");
    var input = new[]
        {
            "[13:49:13] [System Message] <Username>  has openned blocked website", 
            "[13:49:14] <Username> accessed file X",
            "[13:52:46] [System Message] <Username>  has entered this room",
            "[13:52:49] [System Message] <Username>  has left this room"
        };
    foreach (var line in input) {
        var match = regex.Match(line);
        if (!match.Success) {
            throw new ArgumentException();
        }
        Console.WriteLine("NEW MESSAGE:");
        Console.WriteLine("     Time: " + match.Groups[1]);
        Console.WriteLine("     Type: " + match.Groups[2]);
        Console.WriteLine("     User: " + match.Groups[4]);
        Console.WriteLine("     Text: " + match.Groups[5]);
    }
