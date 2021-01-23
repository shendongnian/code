    public static bool ContainsSubequence<T>(this IEnumerable<T> parent, IEnumerable<T> target)
    {
        using (IEnumerator<T> parentEnum = parent.GetEnumerator())
        {
            using (IEnumerator<T> targetEnum = target.GetEnumerator())
            {
                // Get the first target instance; empty sequences are trivially contained
                if (!targetEnum.MoveNext())
                    return true;
                while (parentEnum.MoveNext())
                {
                    if (targetEnum.Current.Equals(parentEnum.Current))
                    {
                        // Match, so move the target enum forward
                        if (!targetEnum.MoveNext())
                        {
                            // We went through the entire target, so we have a match
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
