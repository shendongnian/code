public static T SetToDefault<T>(T the_obj)
{
    return default(T);
}
public static IEnumerable<T> SetToDefault<T>(IEnumerable<T> the_enumerable) {
    return the_enumerable.Select(value => default(T));
}
