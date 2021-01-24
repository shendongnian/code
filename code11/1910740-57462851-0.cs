        var tmp = File.ReadAllText("TextFile1.txt");
        var result = Regex.Match(tmp, "This is the text I want to get", RegexOptions.Multiline);
        if (result.Groups.Count> 0)
            for (int i = 0; i < result.Groups.Count; i++)
                Console.WriteLine(result.Groups[i].Value);
        else
            Console.WriteLine("string not found.");
