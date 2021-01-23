    string numbers = "123456789";
    string example = "12345 1123456 19283741 987654321";
    
    var matches = Regex.Matches(example, @"\d+");
    for (int i = 0; i < matches.Count; i++) {
        var match = matches[i].Value;
        if (!numbers.Any(number => match.Count(x => x == number) >= 2)) {
            Console.WriteLine(match);
        }
    }
    
    
