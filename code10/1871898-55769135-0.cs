    var lines = File.ReadLines(filePath);
    var separator = new[] {','};
    var result = lines.AsParallel().AsOrdered().Select((line, index) =>
    {
        var values = line?.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            .Select(f => float.Parse(f, CultureInfo.InvariantCulture)).ToArray();
        return (index, values);
    }).ToDictionary(d => d.Item1, d => d.Item2);
