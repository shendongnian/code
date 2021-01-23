    var lines = new List<MyObject>
                    {
                        new MyObject { LineId = 1 },
                        new MyObject { LineId = 1 },
                        new MyObject { LineId = 1 },
                        new MyObject { LineId = 2 },
                        new MyObject { LineId = 1 },
                        new MyObject { LineId = 2 },
                    };
    
    IEnumerable<List<int>> consecutiveLineIds = lines
        .Select((line, i) => new
        {
            Line = line,
            Boundary = i + lines.Skip(i)
                                .TakeWhile(l => l.LineId == line.LineId).Count() - 1
        })
        .GroupBy(item => item.Boundary, item => item.Line.LineId)
        .Select(g => g.ToList());
