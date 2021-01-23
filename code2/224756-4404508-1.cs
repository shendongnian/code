    public class Foo<T>
    {
        static Foo()
        {
            if (!typeof(ISerializable).IsAssignableFrom(typeof(T))
                || !typeof(T).GetCustomAttributes(true).OfType<SerializableAttribute>().Any())
            {
                throw new InvalidOperationException(string.Format("Type {0} is not serializable.", typeof(T).FullName));
            }
        }
    }
