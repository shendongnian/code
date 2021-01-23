    public static IEnumerable<IEnumerable<Point>> GetGroupedPoints(this IEnumerable<Point> points)
    {
        Point? prevPoint = null;
        List<Point> currentGroup = new List<Point>();
        foreach (var point in points)
        {
            if(prevPoint.HasValue && point!=prevPoint)
            {
                //new group
                yield return currentGroup;
                currentGroup = new List<Point>();
            }
            currentGroup.Add(point);
            prevPoint = point;
        }
        if(currentGroup.Count > 0)
            yield return currentGroup;
    }
