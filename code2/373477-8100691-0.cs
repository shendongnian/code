    static IEnumerable<Range> GroupContinuous(this IEnumerable<Range> ranges)
    {
        // Validate parameters.
        // Can order by start date, no overlaps, no collisions
        ranges = ranges.OrderBy(r => r.Start);
        // Get the enumerator.
        using (IEnumerator<Range> enumerator = ranges.GetEnumerator();
        {
            // Move to the first item, if nothing, break.
            if (!enumerator.MoveNext()) yield break;
            // Set the previous range.
            Range previous = enumerator.Current;
            // Cycle while there are more items.
            while (enumerator.MoveNext())
            {
                // Get the current item.
                Range current = enumerator.Current;
                // If the start date is equal to the end date
                // then merge with the previous and continue.
                if (current.Start == previous.End)
                {
                    // Merge.
                    previous = new Range(previous.Start, current.End);
                    // Continue.
                    continue;
                }
                // Yield the previous item.
                yield return previous;
                // The previous item is the current item.
                previous = current;
            }
            // Yield the previous item.
            yield return previous;
        }
    }
