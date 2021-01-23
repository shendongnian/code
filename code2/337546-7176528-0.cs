    public class Factory{
        public static T Get<T, V>(V v)
            where T : BaseClass<V> {
                T someObject = DIContainer.Resolve<T>();
                someObject.Set(v);
        }
    }
