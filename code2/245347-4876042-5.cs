    IEnumerable<byte> bytesEnumerable = GetBytesFromList(list);
    byte[] newArray = bytesEnumerable.ToArray();
    private static IEnumerable<T> GetBytesFromList<T>(IEnumerable<IEnumerable<T>> list)
    {
        foreach (IEnumerable<T> elements in list)
        {
            foreach (T element in elements)
            {
                yield return element;
            }
        }
    }
