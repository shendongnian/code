    public static IEnumerable<IEnumerable<T>> OfSequenceType<T>
        (this IEnumerable source) where T : struct
    {
        // Nullity check elided...
        foreach (object x in source)
        {
            IEnumerable<T> sequence = x as IEnumerable<T>;
            if (sequence == null)
            {
                continue;
            }
            // Work around odd value type array variance
            Type type = sequence.GetType();
            if (type.IsArray && type.GetElementType() != typeof(T))
            {
                continue;
            }
            yield return sequence;
        }
    }
