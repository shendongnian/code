    public static IEnumerable<IEnumerable<T>> OfSequenceType<T>
        (this IEnumerable source) where T : struct
    {
        // Nullity check elided...
        foreach (object x in source)
        {
            IEnumerable<T> sequence = x as IEnumerable<T>;
            if (x == null)
            {
                 break;
            }
            // Work around odd value type array variance
            Type type = sequence.GetType();
            if (type.IsArray && type.GetElementType() != typeof(T))
            {
                break;
            }
            yield return sequence;
        }
    }
