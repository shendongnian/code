    class ReflectionComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            Type type = typeof(T);
            if( typeof(IEquatable<T>).IsAssignableFrom(type) )
                return EqualityComparer<T>.Default.Equals(x, y);
            Type enumerableType = type.GetInterface(typeof(IEnumerable<>).FullName);
            if( enumerableType != null )
            {
                Type elementType = enumerableType.GetGenericArguments()[0];
                Type elementComparerType = typeof(ReflectionComparer<>).MakeGenericType(elementType);
                object elementComparer = Activator.CreateInstance(elementComparerType);
                return (bool)typeof(Enumerable).GetMethod("SequenceEqual")
                                               .MakeGenericMethod(elementType)
                                               .Invoke(null, new object[] { x, y, elementComparer });
            }
            foreach( PropertyInfo prop in type.GetProperties() )
            {
                Type propComparerType = typeof(ReflectionComparer<>).MakeGenericType(prop.PropertyType);
                object propComparer = Activator.CreateInstance(propComparerType);
                if( !((bool)typeof(IEqualityComparer<>).MakeGenericType(prop.PropertyType)
                                                       .GetMethod("Equals")
                                                       .Invoke(propComparer, new object[] { prop.GetValue(x, null), prop.GetValue(y, null) })) )
                    return false;
            }
            return true;
        }
        public int GetHashCode(T obj)
        {
            throw new NotSupportedException();
        }
    }
