public T M<T>(IDataReader reader)
{
    if (typeof(T) == typeof(long))
    {
        long result = reader.GetInt64(_keyFieldReaderIndex);
        return Unsafe.As<long, T>(ref result);
    }
    if (typeof(T) == typeof(short))
    {
        short result = reader.GetInt16(_keyFieldReaderIndex);
        return Unsafe.As<short, T>(ref result);
    }
    // etc...
}
(You'll need the [`System.Runtime.CompilerServices.Unsafe`](https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe/) NuGet package if you're not using .NET Core.)
**However**, I'm not convinced this is a sensible thing to be doing. Presumably you've got some code which is doing:
bool result = GetKey<bool>(reader);
Why not just change this code to read:
bool result = reader.GetBoolean(_keyFieldReaderIndex);
Failing that, I'd prefer to write out a bunch of helper methods, like:
public bool GetBoolean(IDataReader reader) => reader.GetBoolean(_keyFieldReaderIndex);
That will be significantly shorter (one line per type, as opposed to 5 lines per type if you use the generic method above), avoids the `Unsafe` business, and is a bit nicer to use.
