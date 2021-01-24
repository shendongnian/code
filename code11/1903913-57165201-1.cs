    static IEnumerable<Func<IStrategy>> GetByBaseType<T>() =>
        typeof(T)
            .Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(T)) && t.GetInterface(nameof(IStrategy)) != null)
            // We assume t has a parameterless constructor
            .Select(t => (Func<IStrategy>)(() => (IStrategy)Activator.CreateInstance(t)));
