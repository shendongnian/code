        /// <summary>
        /// Calculates continues ranges based on individual elements lower and upper selections. Cannot compensate for overlapping.
        /// </summary>
        /// <typeparam name="T">The type containing a range</typeparam>
        /// <typeparam name="T1">The type of range values</typeparam>
        /// <param name="source">The ranges to be combined</param>
        /// <param name="lowerSelector">The range's lower bound</param>
        /// <param name="upperSelector">The range's upper bound</param>
        /// <param name="factory">A factory to create a new range</param>
        /// <returns>An enumeration of continuous ranges</returns>
        public static IEnumerable<T> ContinousRange<T, T1>(this IEnumerable<T> source, Func<T, T1> lowerSelector, Func<T, T1> upperSelector, Func<T1, T1, T> factory)
        {
            //Validate parameters
            // Can order by start date, no overlaps, no collisions
            source = source.OrderBy(lowerSelector);
            // Get enumerator
            using(var enumerator = source.GetEnumerator())
            {
                // Move to the first item, if nothing, break.
                if (!enumerator.MoveNext()) yield break;
                // Set the previous range.
                var previous = enumerator.Current;
                // Cycle while there are more items
                while(enumerator.MoveNext())
                {
                    // Get the current item.
                    var current = enumerator.Current;
                    // If the start date is equal to the end date
                    // then merge with the previoud and continue
                    if (lowerSelector(current).Equals(upperSelector(previous)))
                    {
                        // Merge
                        previous = factory(lowerSelector(previous), upperSelector(current));
                        // Continue
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
