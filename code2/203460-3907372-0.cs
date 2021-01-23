    public static class ObjectExtension
    {
        public static bool In(this object obj, params object[] objects)
        {
            if (objects == null || obj == null)
                return false;
            object found = objects.FirstOrDefault(o => o.GetType().Equals(obj.GetType()) && o.Equals(obj));
            return (found != null);
        }
    }
