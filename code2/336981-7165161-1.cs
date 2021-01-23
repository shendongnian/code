    static IEnumerable<T> UnionSorted<T>(IEnumerable<T> sortedLeft, IEnumerable<T> sortedRight, IComparer<T> comparer)
    {
        var first = true;
        var continueLeft = true;
        var continueRight = true;
        T left = default(T);
        T right = default(T);
        using (var el = sortedLeft.GetEnumerator())
        using (var er = sortedRight.GetEnumerator())
        {
            // Loop until both enumeration are done.
            while (continueLeft | continueRight)
            {
                // Only if both enumerations have values.
                if (continueLeft & continueRight)
                {
                    // Seed the enumeration.
                    if (first)
                    {
                        continueLeft = el.MoveNext();
                        if (continueLeft)
                            left = el.Current;
                        continueRight = er.MoveNext();
                        if (continueRight)
                            right = er.Current;
                        first = false;
                    }
                    // Compare them and decide which to return.
                    var comp = comparer.Compare(left, right);
                    if (comp < 0)
                    {
                        yield return left;
                        // We only advance left until they match.
                        continueLeft = el.MoveNext();
                        if (continueLeft)
                            left = el.Current;
                    }
                    else if (comp > 0)
                    {
                        yield return right;
                        continueRight = er.MoveNext();
                        if (continueRight)
                            right = er.Current;
                    }
                    else
                    {
                        // The both match, so advance both.
                        yield return left;
                        continueLeft = el.MoveNext();
                        if (continueLeft)
                            left = el.Current;
                        continueRight = er.MoveNext();
                        if (continueRight)
                            right = er.Current;
                    }
                }
                // One of the lists is done, don't advance it.
                else if (continueLeft)
                {
                    yield return left;
                    continueLeft = el.MoveNext();
                    if (continueLeft)
                        left = el.Current;
                }
                else if (continueRight)
                {
                    continueRight = er.MoveNext();
                    if (continueRight)
                        right = er.Current;
                }
            }
        }
    }
