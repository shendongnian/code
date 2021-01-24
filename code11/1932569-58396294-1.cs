        var pointsStrings = coordinates.Split(new[] {"   "}, StringSplitOptions.RemoveEmptyEntries);
        var points = pointsStrings
            .Select(ps => ps.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
            .Select(ps => new { X = ps[0], Y = ps[1]});
        foreach (var point in points)
        {
            Console.WriteLine($"X = {point.X}, Y = {point.Y}");
        }
