    private IEnumerable<Path> GetContinuations(Path path)
    {
        var e = path.Elements.LastOrDefault();
        if (e == null)
            return new Path[] { null };
        return new[]
        {
            maze.GetElementAt(e.X, e.Y - 1),
            maze.GetElementAt(e.X, e.Y + 1),
            maze.GetElementAt(e.X - 1, e.Y),
            maze.GetElementAt(e.X + 1, e.Y)
        }
        .Where(i => i != null)
        .OrderBy(i => Math.Sqrt(Math.Pow(end.X - i.X, 2) + Math.Pow(end.Y - i.Y, 2)))
        .Select(i => GetContinuedPath(path, i));
    }
	
