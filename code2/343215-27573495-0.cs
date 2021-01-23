    /// <summary>
    /// Encapsulates useful functions to map domain objects with presentation objects.
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Converts an object of <typeparamref name="U"/> to an object of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="instanceOfU"></param>
        /// <returns></returns>
        public static T Convert<U, T>(U instanceOfU)
            where T : class, new()
            where U : class, new()
        {
            T instanceOfT = new T();
            PropertyInfo[] tPropertyInfos = typeof(T).GetProperties();
            PropertyInfo[] uPropertyInfos = typeof(U).GetProperties();
            foreach (PropertyInfo tPropertyInfo in tPropertyInfos)
            {
                foreach (var uPropertyInfo in uPropertyInfos.Where(p => p.Name == tPropertyInfo.Name))
                {
                    if (tPropertyInfo.PropertyType == uPropertyInfo.PropertyType
                        && tPropertyInfo.SetMethod != null)
                    {
                        tPropertyInfo.SetValue(instanceOfT, uPropertyInfo.GetValue(instanceOfU));
                    }
                }
            }
            return instanceOfT;
        }
        /// <summary>
        /// Converts an instance of type <typeparamref name="TChaild"/> to an instance of its parent type: <typeparamref name="TParent"/>.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <typeparam name="TParent"></typeparam>
        /// <param name="child"></param>
        /// <returns></returns>
        public static TParent ConvertChildToParent<TChild, TParent>(TChild child)
            where TParent : class, new()
            where TChild : class, new()
        {
            if (!typeof(TChild).IsDerivedFrom(typeof(TParent)))
            {
                throw new ArgumentException(string.Format("{0} is not derived from {1}.", typeof(TChild), typeof(TParent)), "TChild");
            }
            return Convert<TChild, TParent>(child);
        }
        /// <summary>
        /// Check if this type is derived from <typeparamref name="parentType"/>.
        /// </summary>
        /// <param name="thisType"></param>
        /// <param name="parentType"></param>
        /// <returns></returns>
        public static bool IsDerivedFrom(this Type thisType, Type parentType)
        {
            Type derivedType = thisType;
            do
            {
                derivedType = derivedType.BaseType;
                if (derivedType != null)
                {
                    if (derivedType == parentType) { return true; }
                }
            } while (derivedType != null);
            return false;
        }
    }
