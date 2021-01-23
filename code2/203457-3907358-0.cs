    public static class Ext {    
        public static bool In<T>(this T t,params T[] values){
            foreach (T value in values) {
                if (t.Equals(value)) {
                    return true;
                }
            }
            return false;
        }
    }
    if (value.In(1,2)) {
        // ...
    }
