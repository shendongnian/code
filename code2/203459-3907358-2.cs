    public static class Ext {    
        public static bool In<T>(this T t,params T[] values){
            return values.Contains(t);
        }
    }
