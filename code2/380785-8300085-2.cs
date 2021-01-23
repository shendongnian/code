    public static IEnumerable<T> Zip<T>(IEnumerable<T> first, IEnumerable<T> second, Func<T,T,T> aggregator)
    {
        using (var firstEnumerator = first.GetEnumerator())
        using (var secondEnumerator = second.GetEnumerator())
        {
            var movedFirstButNotSecond = false;
            while ((movedFirstButNotSecond = firstEnumerator.MoveNext()) && secondEnumerator.MoveNext())
            {
                yield return aggregator(firstEnumerator.Current, secondEnumerator.Current);
                movedFirstButNotSecond = false;                
            }
            while (movedFirstButNotSecond || firstEnumerator.MoveNext())
            {
                yield return firstEnumerator.Current;
                movedFirstButNotSecond = false;
            }
            while (secondEnumerator.MoveNext())
            {
                yield return secondEnumerator.Current;
            }
        }
    }
