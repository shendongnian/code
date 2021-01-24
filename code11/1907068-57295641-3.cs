    List<int> numbers = "input|123|456|mix3d"
        .Split('|')
        .Where(item => item.Any(char.IsDigit))
        .Select(item => int.Parse(string.Concat(item.Where(char.IsDigit))))
        .ToList();
    // numbers == { 123, 456, 3 }
