        private Type CreateOpenDelegate()
        {
            var parms = _method.GetParameters();
            bool hasReturn = _method.ReturnType != typeof (void);
            Type generic = GetGenericTypeForOpenDelegate(parms, hasReturn);
            var argTypes = new List<Type>(parms.Length + 2) {_method.DeclaringType};
            foreach (var arg in parms)
            {
                if(arg.IsOut || arg.IsRetval)
                    throw new NotImplementedException();
                argTypes.Add(arg.ParameterType);
            }
            if(hasReturn)
                argTypes.Add(_method.ReturnType);
            var result = generic.MakeGenericType(argTypes.ToArray());
            return result;
        }
        private static Type GetGenericTypeForOpenDelegate(ParameterInfo[] parms, bool hasReturn)
        {
            if (hasReturn)
            {
                switch (parms.Length)
                {
                    case 0:
                        return typeof (Func<,>);
                        break;
                    case 1:
                        return typeof (Func<,,>);
                        break;
                    case 2:
                        return typeof (Func<,,,>);
                        break;
                    case 3:
                        return typeof (Func<,,,,>);
                        break;
                }
            }
            else
            {
                switch (parms.Length)
                {
                    case 0:
                        return typeof (Action<>);
                        break;
                    case 1:
                        return typeof (Action<,>);
                        break;
                    case 2:
                        return typeof (Action<,,>);
                        break;
                    case 3:
                        return typeof (Action<,,,>);
                        break;
                }
            }
            throw new NotImplementedException();
        }
