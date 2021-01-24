    public static IEnumerable<Coords> GetCoordinates(Coords position, int range)
    {
        for (int i = position.X - range; i <= position.X + range; i++)
            for (int j = position.Y - range; j <= position.Y + range; j++)
                yield return new Coords() { X = i, Y = j };
    }
