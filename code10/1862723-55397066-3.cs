       string report = string.Join(", ", Enumerable
        .Range(0, Math.Max(ExpectedList.Count, ActualList.Count))
        .Select(i => new {
          expected = i < ExpectedList.Count ? ExpectedList[i] : "empty",
          actual = i < ActualList.Count ? ActualList[i] : "empty",
        })
        .Where(item => item.actual != item.expected)
        .Select(item => $"{item.expected} {item.actual}"));
