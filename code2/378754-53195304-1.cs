    public List<object> Foo(IEnumerable<object> objects)
    {
        object firstObject;
        if (objects == null || !TryPeek(ref objects, out firstObject))
            throw new ArgumentException();
        var list = DoSomeThing(firstObject);
        var secondList = DoSomeThingElse(objects);
        list.AddRange(secondList);
        return list;
    }
    public static bool TryPeek<T>(ref IEnumerable<T> source, out T first)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        IEnumerator<T> enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            first = default(T);
            source = Enumerable.Empty<T>();
            return false;
        }
        first = enumerator.Current;
        T firstElement = first;
        source = Iterate();
        return true;
        IEnumerable<T> Iterate()
        {
            yield return firstElement;
            using (enumerator)
            {
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
