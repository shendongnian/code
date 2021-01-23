    public static class Ext
    {
        public static bool IsPrimitive(this Type t)
        {
            return t == typeof(int) || t == typeof(float) 
                || t == typeof(double) || ...
        }
    }
