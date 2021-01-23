    public static dynamic DynamicCastTo(this dynamic obj, Type castTo, bool safeCast)
    {
       MethodInfo castMethod = this.GetType().GetMethod("CastTo").MakeGenericMethod(castTo);
       return castMethod.Invoke(null, new object[] { obj, safeCast });
    }
