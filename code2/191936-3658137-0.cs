    public interface IGeoPrimitive<out T> : IPrimitive
        where T : IGeoPrimitiveContent
    {
        T Content { get; }
    }
