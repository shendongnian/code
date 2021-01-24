    string[] data = new string[]
    {
        "1R09ST75057",
        "1R11ST75070",
        "1R15ST75086",
        "1R23ST75090",
        "2R05HS75063",
        "2R05ST75063",
        "3R05ST75086",
        "2R07HS75086"
    };
    string pattern = "3*05ST75086";
    string[] results = data
        .Where(x => System.Text.RegularExpressions.Regex.IsMatch(x, pattern))
        .ToArray();
