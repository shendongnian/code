    public static IEnumerable<Item> Reduce(this IEnumerable<Item> items)
    {
        using (var iterator = items.GetEnumerator())
        {
            if (!iterator.MoveNext())
                yield break;
    
            var previous = iterator.Current;
    
            while (iterator.MoveNext())
            {
                var next = iterator.Current;
                var containsPrevious =
                    previous.Sentence == next.Sentence &&
                    next.Subject.Contains(previous.Subject) &&
                    next.Object.Contains(previous.Object);
    
                if (!containsPrevious)
                    yield return previous;
    
                previous = next;
            }
    
            yield return previous;
        }
    }
