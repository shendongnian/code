    public static T WithNewGuid<T>(this T o) where T : class, IHasID<Guid>
    {
        if (o == null) return o;
        o.GetType().InvokeMember("ID", BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, o, new object[] { Guid.NewGuid() });
        return o;
    }
