    public string Truncate(string input)
    {
        int index = input.IndexOf(' ', 50);
        return input.Substring(0, index) + "...";
    }
    ...
    string foo ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean in vehicula nulla. Phasellus libero dui, luctus quis bibendum sit amet";
    string bar = Truncate(foo);
    Console.WriteLine(bar);
