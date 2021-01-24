    public static class Extensions
    {
        #region Object Methods
    
        public static bool TryCallMethod<T>(this object obj, string methodName, out T result, params object[] args) where T : class
        {
            result = null;
            var method = obj.GetType().GetMethod(methodName);
    
            if (method == null)            
                return false;
            result = method.Invoke(obj, args) as T;
            return true;
        }
    
        #endregion
    }
