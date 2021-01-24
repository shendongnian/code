    List<int> numbers = "input|123|456|mix3d"
        .Split('|')
        .Where(item => item.Any(char.IsNumber))
        .Select(item => int.Parse(string.Concat(item.Where(char.IsNumber))))
        .ToList();
