    public class MyTestClass<T>
        where T : struct, IConvertible // Try to get as much of a static check as we can.
    {
        // The .NET framework doesn't provide a compile-checked
        // way to ensure that a type is an enum, so we have to check when the type
        // is statically invoked.
        static EnumUtil()
        {
            // Throw Exception on static initialization if the given type isn't an enum.
            if(!typeof (T).IsEnum) 
                throw new Exception(typeof(T).FullName + " is not an enum type.");
        }
        Dictionary<T, List<T>> Changes = new Dictionary<T, List<T>>();
        ...
    }
