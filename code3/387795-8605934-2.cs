    public static class ProxyExtensions
    {
        public static IEnumerable<T> ProxyAddMixins<T>(this IEnumerable<T> collection, params Func<T, object>[] mixinSelectors)
            where T : class
        {
            ProxyGenerator factory = new ProxyGenerator();
            foreach (T item in collection)
            {
                ProxyGenerationOptions o = new ProxyGenerationOptions();
                foreach (var func in mixinSelectors)
                {
                    object mixin = func(item);
                    o.AddMixinInstance(mixin);
                }
                yield return factory.CreateClassProxyWithTarget<T>(item, o);
            }
        }
    }
