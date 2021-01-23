    public static class MyExtentions
    {
        public static string ValueString(this Enum e)
        {
           var ut = Enum.GetUnderlyingType(e.GetType());
           var castToString = typeOf(MyExtentions).GetMethod("CastToString");
           var gcast = cast.MakeGenericMethod(ut);
           var gparams = new object[] {e};
           return gcast.Invoke(null, gparams).ToString();
        }
        public static string CastToString<T>(object o)
        {
            return ((T)o).ToString();
        }
