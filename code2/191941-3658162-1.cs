    // Note addition of 'out' keyword
    public interface IGeoPrimitive<out T> : IPrimitive
        where T : IGeoPrimitiveContent
    {
        T Content { get; }
    }
