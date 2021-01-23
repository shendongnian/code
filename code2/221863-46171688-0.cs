    public static T[] CastArrayToType<T>(object[] collection)
    {
        return Array.ConvertAll<object, T>(
            collection,
            delegate(object prop)
            {
                return (T)prop;
            }
        );
    }
