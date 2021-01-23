        public static bool IsDerivedFrom(this Type type, Type inter)
        {
            if (type.IsSubclassOf(inter))
                return true;
            if (IsDerivedFromImp(type, inter))
                return true;
            foreach (var i in type.GetInterfaces())
            {
                if (IsDerivedFromImp(i, inter))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// type A is equivalent to B if 
        /// 1. They are they same type, AND
        /// 2. Their generic arguments match
        /// </summary>
        /// <param name="iLhs"></param>
        /// <param name="iRhs"></param>
        /// <returns></returns>
        private static bool IsDerivedFromImp(Type iLhs, Type iRhs)
        {
            if (iLhs == iRhs)
            {
                return true;
            }
            if (iLhs.IsGenericType && iRhs.IsGenericType)
            {
                iRhs.GetGenericArguments();
                if (iLhs.GetGenericTypeDefinition() != iRhs.GetGenericTypeDefinition())
                {
                    return false;
                }
                // Generic arguments must be match
                var lhsArgs = iLhs.GetGenericArguments();
                var rhsArgs = iRhs.GetGenericArguments();
                for (int x = 0; x < rhsArgs.Length; x++)
                {
                    // ie IList<> is derived from IList<>, is true
                    if (lhsArgs[x].IsGenericParameter && rhsArgs[x].IsGenericParameter)
                    {
                        continue;
                    }
                    // ie IList<string> is derived from IList<>, is true
                    if (!lhsArgs[x].IsGenericParameter && rhsArgs[x].IsGenericParameter)
                    {
                        continue;
                    }
                    // ie IList<> implements IList<string>, is false
                    if (lhsArgs[x].IsGenericParameter && !rhsArgs[x].IsGenericParameter)
                    {
                        return false;
                    }
                    // ie IDo<string> implements IDo<int>, is false
                    if (lhsArgs[x] != rhsArgs[x])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
