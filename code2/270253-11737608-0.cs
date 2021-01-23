    /// <summary>Framework detection and specific implementations.</summary>
    public static class FrameworkTools
    {
        private static bool _isMono = Type.GetType("Mono.Runtime") != null;
        private static Func<InvokeMemberBinder, IList<Type>> _frameworkTypeArgumentsGetter = null;
        /// <summary>Gets a value indicating whether application is running under mono runtime.</summary>
        public static bool IsMono { get { return _isMono; } }
        static FrameworkTools()
        {
            _frameworkTypeArgumentsGetter = CreateTypeArgumentsGetter();
        }
        private static Func<InvokeMemberBinder, IList<Type>> CreateTypeArgumentsGetter()
        {
            if (IsMono)
            {
                var binderType = typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException).Assembly.GetType("Microsoft.CSharp.RuntimeBinder.CSharpInvokeMemberBinder");
                if (binderType != null)
                {
                    ParameterExpression param = Expression.Parameter(typeof(InvokeMemberBinder), "o");
                    return Expression.Lambda<Func<InvokeMemberBinder, IList<Type>>>(
                        Expression.TypeAs(
                            Expression.Field(
                                Expression.TypeAs(param, binderType), "typeArguments"),
                            typeof(IList<Type>)), param).Compile();
                }
            }
            else
            {
                var inter = typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException).Assembly.GetType("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder");
                if (inter != null)
                {
                    var prop = inter.GetProperty("TypeArguments");
                    if (!prop.CanRead)
                        return null;
                    var objParm = Expression.Parameter(typeof(InvokeMemberBinder), "o");
                    return Expression.Lambda<Func<InvokeMemberBinder, IList<Type>>>(
                        Expression.TypeAs(
                            Expression.Property(
                                Expression.TypeAs(objParm, inter),
                                prop.Name),
                            typeof(IList<Type>)), objParm).Compile();
                }
            }
            return null;
        }
        /// <summary>Extension method allowing to easyly extract generic type arguments from <see cref="InvokeMemberBinder"/>.</summary>
        /// <param name="binder">Binder from which get type arguments.</param>
        /// <returns>List of types passed as generic parameters.</returns>
        public static IList<Type> GetGenericTypeArguments(this InvokeMemberBinder binder)
        {
            // First try to use delegate if exist
            if (_frameworkTypeArgumentsGetter != null)
                return _frameworkTypeArgumentsGetter(binder);
            if (_isMono)
            {
                // In mono this is trivial.
                // First we get field info.
                var field = binder.GetType().GetField("typeArguments", BindingFlags.Instance |
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                // If this was a success get and return it's value
                if (field != null)
                    return field.GetValue(binder) as IList<Type>;
            }
            else
            {
                // In this case, we need more aerobic :D
                // First, get the interface
                var inter = binder.GetType().GetInterface("Microsoft.CSharp.RuntimeBinder.ICSharpInvokeOrInvokeMemberBinder");
                if (inter != null)
                {
                    // Now get property.
                    var prop = inter.GetProperty("TypeArguments");
                    // If we have a property, return it's value
                    if (prop != null)
                        return prop.GetValue(binder, null) as IList<Type>;
                }
            }
            // Sadly return null if failed.
            return null;
        }
    }
