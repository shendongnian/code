    public static bool ContainsSubequence<T>(this IEnumerable<T> parent, IEnumerable<T> target)
    {
        bool foundOneMatch = false;
        var enumeratedTarget = target.ToList();
        int enumPos = 0;
        using (IEnumerator<T> parentEnum = parent.GetEnumerator())
        {
            while (parentEnum.MoveNext())
            {
                if (enumeratedTarget[enumPos].Equals(parentEnum.Current))
                {
                    // Match, so move the target enum forward
                    foundOneMatch = true;
                    if (enumPos == enumeratedTarget.Count - 1)
                    {
                        // We went through the entire target, so we have a match
                        return true;
                    }
                    enumPos++;
                }
                else if (foundOneMatch)
                {
                    foundOneMatch = false;
                    enumPos = 0;
                    if (enumeratedTarget[enumPos].Equals(parentEnum.Current))
                    {
                        foundOneMatch = true;
                        enumPos++;
                    }
                }
            }
            return false;
        }
    }
