    public static T WithID<T, K>(this T o, K id) where T : class, IHasID<K>
    {
        if (o == null) return o;
        o.GetType().InvokeMember("ID", BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, o, new object[] { id });
        return o;
    }
