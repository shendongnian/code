    public static IEnumerable<IList<Couple>> Split(IEnumerable<Couple> couples)
    {
        using (var enumerator = couples.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                yield break;
            }
            var current = enumerator.Current;
            var group = new List<Couple> { current };
            while (enumerator.MoveNext())
            {
                var next = enumerator.Current;
                if (current.Indicator.Equals(next.Indicator))
                {
                    group.Add(next);
                }
                else
                {
                    yield return group;
                    group = new List<Couple> { next };
                }
                current = next;
            }
            yield return group;
        }
    }
