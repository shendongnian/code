    var list = Array.ConvertAll(strings, s => Int32.Parse(s)).OrderBy(i => i);
    // or
    var list = strings.Select(s => int.Parse(s)).OrderBy(i => i);
    // or
    var list = strings.OrderBy(s => int.Parse(s));
