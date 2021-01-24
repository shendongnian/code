csharp
public static class ConverterContainer
{
    private static readonly Dictionary<(Type, Type), Delegate> _converters = new Dictionary<(Type, Type), Delegate>();
    public static void Register<TInput, TOutput>(Func<TInput, TOutput> converter)
    {
        if (converter is null)
            throw new ArgumentNullException(nameof(converter));
        _converters[(typeof(TInput), typeof(TOutput))] = converter;
    }
    public static TOutput Convert<TInput, TOutput>(TInput input)
    {
        if (_converters.TryGetValue((typeof(TInput), typeof(TOutput)), out var del))
        {
            Func<TInput, TOutput> converter = (Func<TInput, TOutput>)del;
            return converter(input);
        }
        throw new InvalidOperationException("Converter not registered.");
    }
}
What it *does not* have:
* thread safety.  This is left as an exercise to a serious implementor.
* possibly other things I didn't take the time to consider.
How to use it:
At startup of your application, register converters, like registering services for dependency injection.
csharp
ConverterContainer.Register<long, int>(l => (int)l);
// ... etc.
And wherever you want to perform conversion between a registered pair of input/output types:
charp
int x = ConverterContainer.Convert<long, int>(1000L)
Unfortunately, you *do* have to specify both type arguments here.
----------------
**Addition from the OP:**
To not have to specify the input parameter type (which is kind of the point of having a dynamic list of available conversions) I use the following additional method in the sample `ConverterContainer` above:
public static TOutput Convert<TOutput>(object toConvert) {
    if (Converters.TryGetValue((toConvert.GetType(), typeof(TOutput)), out Delegate conv)) {
        object o = conv.DynamicInvoke(toConvert);
        return (TOutput) o;
    }
    throw new InvalidOperationException($"Converter not registered for types: {toConvert.GetType().Name} -> {typeof(TOutput).Name}");
}
You can now throw in any random `object` crap and see if the conversion to your desired type is possible.
