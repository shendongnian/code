    public static IServiceCollection Add(
        this IServiceCollection collection,
        ServiceDescriptor descriptor)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }
        if (descriptor == null)
        {
            throw new ArgumentNullException(nameof(descriptor));
        }
        collection.Add(descriptor);
        return collection;
    }
