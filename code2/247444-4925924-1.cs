    dynamic DynamicCast(object entity, Type to)
    {
        var openCast = this.GetType().GetMethod("Cast", BindingFlags.Static | BindingFlags.NonPublic);
        var closeCast = openCast.MakeGenericMethod(to);
        return closeCast.Invoke(entity, new[] { entity });
    }
    static T Cast<T>(object entity) where T : class
    {
        return entity as T;
    }
