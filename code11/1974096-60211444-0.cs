public static TimeSpan? GetTimeout(this HttpRequestMessage request)
{
    if ( request == null )
        throw new ArgumentNullException (nameof (request));
    object value;
    if ( request.Properties.TryGetValue(TimeoutPropertyKey, out value)
        && value is TimeSpan )
    {
        return (TimeSpan)value;
    }
    return null;
}
You can even use `as` with a `TimeSpan?`. This results in a `null` value if `value` doesn't contain a boxed `TimeSpan`.
public static TimeSpan? GetTimeout(this HttpRequestMessage request)
{
    if ( request == null )
        throw new ArgumentNullException (nameof (request));
    object value;
    if ( request.Properties.TryGetValue(TimeoutPropertyKey, out value) )
    {
        return value as TimeSpan?;
    }
    return null;
}
