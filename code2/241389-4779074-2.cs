    public static Action<T> GetLockedAdd<T>(IList<T> list)
    {
        var lockObj = new object();
        return x =>
        {
            lock (lockObj)
            {
                list.Add(x);
            }
        }
    }
