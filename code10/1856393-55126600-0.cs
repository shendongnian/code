    var source = new List<string> {
        "burger 5$",
        "pizza 6$",
        "roll 1$ and salami 2$"
    };
    
    var result = new List<int>();
    
    foreach (var input in source)
    {
        var numbers = Regex.Split(input, @"\D+");
        foreach (string number in numbers)
        {
            if (Int32.TryParse(number, out int value))
            {
                result.Add(value);
            }
        }
    }
