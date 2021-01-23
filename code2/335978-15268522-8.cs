    var t = (RuntimeType)typeof(T);
    // If T is byte,
    // return a ByteEqualityComparer.
    // If T implements IEquatable<T>,
    if (typeof(IEquatable<T>).IsAssignableFrom(t))
        return (EqualityComparer<T>)
               RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter(
                   (RuntimeType)typeof(GenericEqualityComparer<int>), t);
            
    // If T is a Nullable<U> where U implements IEquatable<U>,
    // return a NullableEqualityComparer<U>
    // If T is an int-based Enum,
    // return an EnumEqualityComparer<T>
    // Otherwise return an ObjectEqualityComparer<T>
