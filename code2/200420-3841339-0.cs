    public static class PhpStyleDynamicMethod
    {
        public static void __call(Type @class, object[] parameters)
        {
            // Do stuff here.
        }
        public static object CallOrDefault(this object b, string method, params object[] parameters)
        {
            var methods = b.GetType().GetMethods().Where(m => m.Name == method && DoParametersMatch(m.GetParameters(), parameters));
            var count = methods.Count();
            if (count == 1)
                return methods.Single().Invoke(b, parameters);
            if (count > 1)
                throw new ApplicationException("could not resolve a single method.");
            __call(b.GetType(), parameters);
            return null;
        }
        public static bool DoParametersMatch(ParameterInfo[] parameters, object[] values)
        {
            if (parameters == null && values == null) return true;
            if (parameters == null) return false;
            if (values == null) return false;
            if (parameters.Length != values.Length) return false;
            for(int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var value = values[i];
                if (!parameter.GetType().IsAssignableFrom(value.GetType()))
                    return false;
            }
            return true;
        }
    }
