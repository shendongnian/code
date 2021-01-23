    IEnumerable<List<Line>> consecutiveLines = lines
        .Select((line, i) => new
        {
            Line = line,
            Boundary = i + lines.Skip(i)
                                .TakeWhile(l => l.LineId == line.LineId).Count() - 1
        })
        .GroupBy(item => item.Boundary, item => item.Line)
        .Select(g => g.ToList());
