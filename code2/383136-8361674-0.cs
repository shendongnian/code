    string text = "A string is a data type used in programming, such as an integer and floating point unit, but is used to represent text rather than numbers. It is comprised of a set of characters that can also contain spaces and numbers.";
    var index = text.Select((c, i) => new {Symbol = c, Index = i})
        .Where(c => c.Symbol == ' ' && c.Index >= 50)
        .Select(c => c.Index)
        .FirstOrDefault();
    
    if (index > 0)
    {
        text = text.Remove(index, 1)
            .Insert(index, Environment.NewLine);
    }
