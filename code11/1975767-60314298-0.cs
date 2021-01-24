c#
        private IEnumerable<Type> BaseTypes(Type t)
        {
            do
            {
                yield return t;
                t = t.BaseType;
            } while (t != null);
        }
            var method = new Action<IEnumerable<object>>(MyClass.DoSmthWithCollection).Method.GetGenericMethodDefinition();
            var testParms = new Type[] { typeof(List<int>) };
            var methodParms = method.GetParameters();
            var methodTypes = method.GetGenericArguments();
            var actualTypes = new Type[methodTypes.Length];
            for (var parmIndex = 0; parmIndex < methodParms.Length; parmIndex++)
            {
                var methodParmType = methodParms[parmIndex].ParameterType;
                if (!methodParmType.ContainsGenericParameters)
                    continue;
                var methodParmBaseType = methodParmType.GetGenericTypeDefinition();
                var testParmType = testParms[parmIndex];
                IEnumerable<Type> compareTypes = methodParmType.IsInterface ? testParmType.GetInterfaces() : BaseTypes(testParmType);
                var match = compareTypes.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == methodParmBaseType).Single();
                var testArgs = match.GetGenericArguments();
                var parmArgs = methodParmType.GetGenericArguments();
                for (var i = 0; i < parmArgs.Length; i++)
                {
                    if (parmArgs[i].IsGenericMethodParameter)
                    {
                        for(var idx = 0; idx < methodTypes.Length; idx++)
                            if (methodTypes[idx] == parmArgs[i])
                            {
                                actualTypes[idx] = testArgs[i];
                                break;
                            }
                    }
                }
            }
            var genericMethod = method.MakeGenericMethod(actualTypes);
I hope there's an easier way, but I haven't found one yet.
