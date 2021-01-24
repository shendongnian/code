    char MostCommonDigit(int[] list)
    {
        return list.Aggregate("", (i, j) => $"{i}{j}")
            .GroupBy(c => c)
            .Select(
                g => new {
                    Char = g.Key,
                    Count = g.Count()
            })
            .OrderByDescending(x => x.Count)
            .ThenByDescending(x => x.Char)
            .First().Char;
    }
