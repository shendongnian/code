        private static bool TryCast(object source, Type destType, out object result)
        {
            Type srcType = source.GetType();
            if (srcType == destType)
            {
                result = source;
                return true;
            }
            MethodInfo cast = null;
            while (cast == null && srcType != typeof(object))
            {
                cast = GetCastMethod(srcType, srcType, destType);
                if (cast == null) cast = GetCastMethod(destType, srcType, destType);
                srcType = srcType.BaseType;
            }
            if (cast != null)
            {
                result = cast.Invoke(null, new object[] { source });
                return true;
            }
            if (destType.IsEnum)
            {
                result = Enum.ToObject(destType, source);
                return true;
            }
            result = null;
            return false;
        }
        private static MethodInfo GetCastMethod(Type typeWithMethod, Type srcType, Type destType)
        {
            while (typeWithMethod != typeof(object))
            {
                foreach (MethodInfo method in typeWithMethod.GetMethods(BindingFlags.Static | BindingFlags.Public))
                {
                    if (method.ReturnType == destType && (method.Name == "op_Explicit" || method.Name == "op_Implicit"))
                    {
                        ParameterInfo[] parms = method.GetParameters();
                        if (parms != null && parms.Length == 1 && parms[0].ParameterType == srcType)
                            return method;
                    }
                }
                typeWithMethod = typeWithMethod.BaseType;
            }
            return null;
        }
