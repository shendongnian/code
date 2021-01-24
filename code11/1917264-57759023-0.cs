`
// This is to constrain T in your method and call ToRType()
public interface IConvertableToTReturn
{
    object ToRType(object input);
}
protected List<TReturn> DoSomethingAwesome<T, TReturn>(T thing)
    where T : IConvertableToTReturn
{
    // Do what you need to do. (Return with thing.ToRType())
}
