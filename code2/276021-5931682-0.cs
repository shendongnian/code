    public static class TypeExtensions
    {
        public static MethodInfo GetMethodWp7Workaround(this Type type, string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            return GetMethod(type, name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, null, CallingConventions.Any, null, null);
        }
        public static MethodInfo GetMethodWp7Workaround(this Type type, string name, Type[] types)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (types == null)
            {
                throw new ArgumentNullException("types");
            }
            if (types.Any(t => t == null))
            {
                throw new ArgumentNullException("types");
            }
            return GetMethod(type, name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, null, CallingConventions.Any, types, null);
        }
        public static MethodInfo GetMethodWp7Workaround(this Type type, string name, BindingFlags bindingAttr)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            return GetMethod(type, name, bindingAttr, null, CallingConventions.Any, null, null);
        }
        public static MethodInfo GetMethodWp7Workaround(this Type type, string name, Type[] types, ParameterModifier[] modifiers)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (types == null)
            {
                throw new ArgumentNullException("types");
            }
            if (types.Any(t => t == null))
            {
                throw new ArgumentNullException("types");
            }
            return GetMethod(type, name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, null, CallingConventions.Any, types, modifiers);
        }
        public static MethodInfo GetMethodWp7Workaround(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (types == null)
            {
                throw new ArgumentNullException("types");
            }
            if (types.Any(t => t == null))
            {
                throw new ArgumentNullException("types");
            }
            return GetMethod(type, name, bindingAttr, binder, CallingConventions.Any, types, modifiers);
        }
        public static MethodInfo GetMethodWp7Workaround(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (types == null)
            {
                throw new ArgumentNullException("types");
            }
            if (types.Any(t => t == null))
            {
                throw new ArgumentNullException("types");
            }
            return GetMethod(type, name, bindingAttr, binder, callConvention, types, modifiers);
        }
        private static MethodInfo GetMethod(
            Type type, 
            string name, 
            BindingFlags bindingFlags, 
            Binder binder,
            CallingConventions callConvention,
            Type[] types,
            ParameterModifier[] modifiers)
        {
            if ((bindingFlags & BindingFlags.DeclaredOnly) == BindingFlags.DeclaredOnly)
            {
                return types == null 
                       ? type.GetMethod(name, bindingFlags)
                       : type.GetMethod(name, bindingFlags, binder, callConvention, types, modifiers);
            }
            bool isBaseType = false;
            bindingFlags = bindingFlags | BindingFlags.DeclaredOnly;
            MethodInfo result = null;
            while (result == null && type != null)
            {
                result = 
                    types == null
                       ? type.GetMethod(name, bindingFlags)
                       : type.GetMethod(name, bindingFlags, binder, callConvention, types, modifiers);
                if (isBaseType && result != null && result.IsPrivate)
                {
                    result = null;
                }
                type = type.BaseType;
                if (!isBaseType)
                {
                    isBaseType = true;
                    bindingFlags = bindingFlags & (~BindingFlags.Static);
                }
            }
            return result;
        }
        public static MethodInfo[] GetMethodsWp7Workaround(this Type type)
        {
            return type.GetMethodsWp7Workaround(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        }
        public static MethodInfo[] GetMethodsWp7Workaround(this Type type, BindingFlags flags)
        {
            if ((flags & BindingFlags.DeclaredOnly) == BindingFlags.DeclaredOnly)
            {
                return type.GetMethods(flags);
            }
            
            flags = flags | BindingFlags.DeclaredOnly;
            Type currentType = type;
            bool isBaseType = false;
            var methods = new List<MethodInfo>();
            while (currentType != null)
            {
                var newMethods = currentType.GetMethods(flags).Where(m => ShouldBeReturned(m, methods, isBaseType));
                methods.AddRange(newMethods);
                currentType = currentType.BaseType;
                if (!isBaseType)
                {
                    isBaseType = true;
                    flags = flags & (~BindingFlags.Static);
                }
            }
            return methods.ToArray();
        }
        private static bool ShouldBeReturned(
            MethodInfo method, 
            IEnumerable<MethodInfo> foundMethods,
            bool isCurrentTypeBaseType)
        {
            return !isCurrentTypeBaseType || (!method.IsPrivate && !HasAlreadyBeenFound(method, foundMethods));
        }
        private static bool HasAlreadyBeenFound(
            MethodInfo method,
            IEnumerable<MethodInfo> processedMethods)
        {
            if (!method.IsGenericMethodDefinition)
            {
                return processedMethods.Any(m => m.GetBaseDefinition().Equals(method.GetBaseDefinition()));
            }
            return processedMethods.Any(
                m => m.Name == method.Name &&
                     HaveSameGenericArguments(m, method) &&
                     HaveSameParameters(m, method));
        }
        private static bool HaveSameParameters(MethodInfo method1, MethodInfo method2)
        {
            var parameters1 = method1.GetParameters();
            var parameters2 = method2.GetParameters();
            return parameters1.Length == parameters2.Length &&
                   parameters1.All(parameters2.Contains);
        }
        private static bool HaveSameGenericArguments(MethodInfo method1, MethodInfo method2)
        {
            var genericArguments1 = method1.GetGenericArguments();
            var genericArguments2 = method2.GetGenericArguments();
            return genericArguments1.Length == genericArguments2.Length;
        }
    }
