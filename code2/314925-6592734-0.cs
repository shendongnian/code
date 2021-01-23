    public IEnumerable<Point> GetPoints(int[] coordinates)
    {
        for (int i = 0; i < coordinates.Length; i += 2)
        {
            yield return new Point(coordinates[i], coordinates[i + 1]);
        }
    }
