    int System.Collections.IList.Add(Object item)
    {
        try {
            Add((T) item);
        }
        catch (InvalidCastException) {
            throw ...;
        }
        return Count - 1;
    }
