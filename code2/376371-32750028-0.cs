    /* A class for finding the sizes of types and variables */
    public static class Sizes
    {
        /* Retrieves the size of the generic type T
            Returns the size of 'T' on success, 0 otherwise */
        public static int SizeOf<T>()
        {
            return FetchSizeOf(typeof(T));
        }
        /* Retrieves the size of the type of obj
            Returns the size of 'obj' on success, 0 otherwise */
        public static int SizeOf<T>(T obj)
        {
            return FetchSizeOf(typeof(T));
        }
        /* Retrieves the size of 'type'
            Returns the size of 'type' on success, 0 otherwise */
        public static int SizeOf(this Type type)
        {
            return FetchSizeOf(type);
        }
        /* Gets the size of the specified type
            Returns the size of 'type' on success, 0 otherwise*/
        private static int FetchSizeOf(this Type type)
        {
            if ( typeSizeCache == null )
                CreateCache();
            if ( typeSizeCache != null )
            {
                int size = 0;
                if ( GetCachedSizeOf(type, out size) )
                    return size;
                else
                    return CalcAndCacheSizeOf(type);
            }
            else
                return CalcSizeOf(type);
        }
        /* Attempts to get the size of type from the cache
            Returns true and sets size on success, returns
            false and sets size to 0 otherwise. */
        private static bool GetCachedSizeOf(Type type, out int size)
        {
            size = 0;
            try
            {
                if ( type != null )
                {
                    if ( !typeSizeCache.TryGetValue(type, out size) )
                        size = 0;
                }
            }
            catch
            {
                /*  - Documented: ArgumentNullException
                    - No critical exceptions. */
                size = 0;
            }
            return size > 0;
        }
        /* Attempts to calculate the size of 'type', and caches
            the size if it is valid (size > 0)
            Returns the calclated size on success, 0 otherwise */
        private static int CalcAndCacheSizeOf(Type type)
        {
            int typeSize = 0;
            try
            {
                typeSize = CalcSizeOf(type);
                if ( typeSize > 0 )
                    typeSizeCache.Add(type, typeSize);
            }
            catch
            {
                /*  - Documented: ArgumentException, ArgumentNullException,
                    - Additionally Expected: OutOfMemoryException
                    - No critical exceptions documented. */
            }
            return typeSize;
        }
        /* Calculates the size of a type using dynamic methods
            Return the type's size on success, 0 otherwise */
        private static int CalcSizeOf(this Type type)
        {
            try
            {
                var sizeOfMethod = new DynamicMethod("SizeOf", typeof(int), Type.EmptyTypes);
                var generator = sizeOfMethod.GetILGenerator();
                generator.Emit(OpCodes.Sizeof, type);
                generator.Emit(OpCodes.Ret);
                var sizeFunction = (Func<int>)sizeOfMethod.CreateDelegate(typeof(Func<int>));
                return sizeFunction();
            }
            catch
            {
                /*  - Documented: OutOfMemoryException, ArgumentNullException,
                                  ArgumentException, MissingMethodException,
                                  MethodAccessException
                    - No critical exceptions documented. */
            }
            return 0;
        }
        /* Attempts to allocate the typeSizesCache
            returns whether the cache is allocated*/
        private static bool CreateCache()
        {
            if ( typeSizeCache == null )
            {
                try
                {
                    typeSizeCache = new Dictionary<Type, int>();
                }
                catch
                {
                    /*  - Documented: OutOfMemoryException
                        - No critical exceptions documented. */
                    typeSizeCache = null;
                }
            }
            return typeSizeCache != null;
        }
        /* Static constructor for Sizes, sets typeSizeCache to null */
        static Sizes()
        {
            CreateCache();
        }
        /* Caches the calculated size of various types */
        private static Dictionary<Type, int> typeSizeCache;
    }
