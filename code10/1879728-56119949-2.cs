    public static IEnumerable<IEnumerable<Site>> GroupAdjacent(
        this IEnumerable<Site> source)
    {
        var ordered = source
            .OrderBy(item => item.RouteId)
            .ThenBy(item => item.StartMilepost);
        IEnumerator<Site> enumerator;
        bool finished = false;
        Site current = null;
        using (enumerator = ordered.GetEnumerator())
        {
            while (!finished)
            {
                yield return GetGroup();
            }
        }
        IEnumerable<Site> GetGroup()
        {
            if (current != null) yield return current;
            while (enumerator.MoveNext())
            {
                var previous = current;
                current = enumerator.Current;
                if (previous != null)
                {
                    if (current.RouteId != previous.RouteId) yield break;
                    if (current.StartMilepost != previous.EndMilepost) yield break;
                }
                yield return current;
            }
            finished = true;
        }
    }
