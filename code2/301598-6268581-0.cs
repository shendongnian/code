    // You need this to constrain T in your method and call ToRType()
    public interface IConvertableToTReturn
    {
        object ToRType(int someInt);
    }
    public static IEnumerable<TReturn> DoSomethingAwesome<T, TReturn>(T thing)
        where T : IConvertableToTReturn
    {
        Enumerable.Range(0, 5).Select(xx => thing.ToRType(xx));
    }
