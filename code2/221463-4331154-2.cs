    var url = "http://www.unicode.org/Public/6.0.0/ucd/UnicodeData.txt";
    var query = from line in new WebClient().DownloadString(url).Split('\n')
                where !string.IsNullOrEmpty(line)
                let parts = line.Split(';')
                where parts[4] == "R" || parts[4] == "AL"
                select parts[0];
    foreach (var ch in query)
    {
        Console.WriteLine("U+{0}", ch);
    }
