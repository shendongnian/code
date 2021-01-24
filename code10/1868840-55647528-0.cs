        private static ConcurrentDictionary<int, Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>> _storeCache
            = new ConcurrentDictionary<int, Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>>();
    ...
        private static IShellProperty GenericCreateShellProperty<T>(PropertyKey propKey, T thirdArg)
        {
           ...
            Func<PropertyKey, ShellPropertyDescription, object, IShellProperty> ctor;
            ctor = _storeCache.GetOrAdd((hash, (key, args) -> {
                Type[] argTypes = { typeof(PropertyKey), typeof(ShellPropertyDescription), args.thirdType };
                return ExpressConstructor(args.type, argTypes);
            }, {thirdType, type});
            return ctor(propKey, propDesc, thirdArg);
        }
