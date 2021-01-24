enum KeyCollisionBehavior
{
    SetValue = 0,
    Skip = 1,
    ThrowIfValueDifferent = 2,
    ThrowAlways = 3,
}
internal static class ImmutableDictionaryHelper<TKey, TValue>
{
    private static readonly Func<TKey, TValue, KeyCollisionBehavior, ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>> AddAndFinalize = CreateAddAndFinalize();
    private static Func<TKey, TValue, KeyCollisionBehavior, ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>> CreateAddAndFinalize()
    {
        var originPropertyGetter = typeof(ImmutableDictionary<TKey, TValue>)
            .GetProperty("Origin", BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod(true);
        var addMethod = typeof(ImmutableDictionary<TKey, TValue>)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(m => m.Name == "Add" && m.GetParameters().Length == 4).FirstOrDefault();
        var finalizeMethod = addMethod.ReturnType
            .GetMethod("Finalize", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        var key = Expression.Parameter(typeof(TKey), "key");
        var value = Expression.Parameter(typeof(TValue), "value");
        var behavior = Expression.Parameter(typeof(KeyCollisionBehavior), "behavior");
        var dictionary = Expression.Parameter(typeof(ImmutableDictionary<TKey, TValue>), "dictionary");
        // var convertedBehavior = (ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior)behavior
        var convertedBehavior = Expression.Convert(behavior, addMethod.GetParameters()[2].ParameterType);
        // var origin = dictionary.Origin;
        var origin = Expression.Property(dictionary, originPropertyGetter);
        // var result = Add(key, value, behavior, origin)
        var result = Expression.Call(addMethod, key, value, convertedBehavior, origin);
        // var newDictionary = result.Finalize(dictionary);
        var newDictionary = Expression.Call(result, finalizeMethod, dictionary);
        var func = Expression.Lambda<Func<TKey, TValue, KeyCollisionBehavior, ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>>>(
            newDictionary, key, value, behavior, dictionary).Compile();
        return func;
    }
    public static ImmutableDictionary<TKey, TValue> Add(ImmutableDictionary<TKey, TValue> source, TKey key, TValue value, KeyCollisionBehavior behavior)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        return AddAndFinalize(key, value, behavior, source);
    }
}
