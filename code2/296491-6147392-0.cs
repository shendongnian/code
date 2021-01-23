    string numbers = "1234567890";
    string example = "12345 1123456 19283741 9876543210";
    
    var matches = Regex.Matches(example, @"\d+");
    for (int i = 0; i < matches.Count; i++) {
        var match = matches[i].Value;
        if (!numbers.Any(number => match.Count(x => x == number) >= 2)) {
            Console.WriteLine(match);
        }
    }
    
    
