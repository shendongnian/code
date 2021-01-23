        var numericList = a.Where(i => int.TryParse(i, out _)).OrderBy(j => int.Parse(j)).ToList();
        var nonNumericList = a.Where(i => !int.TryParse(i, out _)).OrderBy(j => j).ToList();
        a.Clear();
        a.AddRange(numericList);
        a.AddRange(nonNumericList);
