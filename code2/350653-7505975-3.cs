    public static class TypeExtension
    {
        public static object FromObject(this Type target, object value)
        {
            var convertable = value as IConvertible;
            if (convertable != null)
            {
                return convertable.ToType(target, null);
            }
            Type type = value.GetType();
            if (target.IsAssignableFrom(type))
            {
                return value;
            }
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (MethodInfo mi in methods)
            {
                if (mi.ReturnType == target)
                {
                    try
                    {
                        return mi.Invoke(null, new object[] { value });
                    }
                    catch (TargetInvocationException caught)
                    {
                        if (caught.InnerException != null)
                        {
                            throw caught.InnerException;
                        }
                        throw;
                    }
                }
            }
            throw new InvalidCastException();
        }
    }
