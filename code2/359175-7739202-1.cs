    public static class ObjectExt
    {
        public static TProp GetPropOrNull<TObj, TProp>(this TObj obj, 
            Func<User,TProp> getProp)
            where TObj : class
            where TProp : class
        {
            if (obj == null)
                return null;
            else
                return getProp(obj);
        }
    }
