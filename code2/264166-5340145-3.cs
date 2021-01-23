    public string Truncate(string input, int length)
    {
        if (input.Length < length) return input;
        int index = input.IndexOf(' ', length);
        return input.Substring(0, index) + "...";
    }
    ...
    string foo ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean in vehicula nulla. Phasellus libero dui, luctus quis bibendum sit amet";
    string bar = Truncate(foo, 50);
    Console.WriteLine(bar);
