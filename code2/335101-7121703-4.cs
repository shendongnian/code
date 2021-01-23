    /// <summary>
    /// Creates a new instance of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of object to create.</typeparam>
    /// <param name="appDomain">The app domain.</param>
    /// <returns>A proxy for the new object.</returns>
    public static T CreateInstanceAndUnwrap<T>(this AppDomain appDomain)
    {
        var res = (T)appDomain.CreateInstanceAndUnwrap(typeof(T));
        return res;
    }
