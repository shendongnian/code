    public static class SynchronizedCollectionExtension
    {
        public static IReadOnlyCollection<T> AsReadOnly<T>(this SynchronizedCollection<T> value)
        {
            lock (value.SyncRoot)
            {
                // this call is not expensive as it is just a thin wrapper around the IList<T>
                return new ReadOnlyCollection<T>(value);
            }
        }
    }
    IReadOnlyCollection<int> readOnlyCollection = collection.AsReadOnly();
