    public class Factory{
        public static T Get<T, V>(V v)
            where T : T<V> {
                T someObject = DIContainer.Resolve<T>();
                someObject.Set(v);
        }
    }
