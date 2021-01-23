    public static IEnumerable<IEnumerable<T>> GetParrallelConsumingEnumerable<T>(this IProducerConsumerCollection<T> collection)
    {
        T item;
        while (collection.TryTake(out item))
        {
            yield return GetParrallelConsumingEnumerableInner(collection, item);
        }
    }
    private static IEnumerable<T> GetParrallelConsumingEnumerableInner<T>(IProducerConsumerCollection<T> collection, T item)
    {
        yield return item;
        while (collection.TryTake(out item))
        {
            yield return item;
        }
    }
