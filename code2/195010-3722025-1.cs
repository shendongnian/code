    public static class RowUtils
    {
        public static Row Read<T>(Stream stream) where T : Row
        {
            var method = typeof(T).GetMethod("Read",
                BindingFlags.Static | BindingFlags.Public);
            if (method == null || !typeof(Row).IsAssignableFrom(method.ReturnType))
                throw new InvalidOperationException(string.Format(
                    "Static Read method on type “{0}” does not exist or " +
                    "has the wrong return type.", typeof(T).FullName));
            return (Row) method.Invoke(null, new object[] { stream });
        }
    }
