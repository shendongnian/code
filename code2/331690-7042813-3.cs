    static void RemoveByPath(IList<YourClass> data, int[] path)
    {
        if (path.Length > 1)
        {
            RemoveByPath(data[path[0]], path.Skip(1).ToArray());
        }
        else
        {
            data.RemoveAt(path[0]);
        }
    }
