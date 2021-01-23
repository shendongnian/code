    public abstract class GetterSetter<S>
    {
        public static GetterSetter<S, T> Create<T>(Expression<Func<S, T>> memberSelector)
        {
            return new GetterSetter<S, T>(memberSelector);
        }
    }
    public class GetterSetter<S, T> : GetterSetter<S>
    {
        Func<S, T> Getter;
        Action<S, T> Setter;
        
        public T this[S instance]
        {
            get { return Getter(instance); }
            set { Setter(instance, value); }
        }
        public GetterSetter(Expression<Func<S, T>> memberSelector)
        {
            var prop = memberSelector.GetPropertyInfo();
            AssignDelegate(out Getter, prop.GetGetMethod());
            AssignDelegate(out Setter, prop.GetSetMethod());
        }
        void AssignDelegate<K>(out K assignee, MethodInfo assignor) where K : class
        {
            assignee = assignor.CreateDelegate<K>();
        }
    }
