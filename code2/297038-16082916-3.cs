    public class Accessor<S>
    {
        public static Accessor<S, T> Create<T>(Expression<Func<S, T>> memberSelector)
        {
            return new GetterSetter<T>(memberSelector);
        }
        public Accessor<S, T> Get<T>(Expression<Func<S, T>> memberSelector)
        {
            return Create(memberSelector);
        }
        public Accessor()
        {
        }
        class GetterSetter<T> : Accessor<S, T>
        {
            public GetterSetter(Expression<Func<S, T>> memberSelector) : base(memberSelector)
            {
            }
        }
    }
    public class Accessor<S, T> : Accessor<S>
    {
        Func<S, T> Getter;
        Action<S, T> Setter;
        public bool IsReadable { get; private set; }
        public bool IsWritable { get; private set; }
        public T this[S instance]
        {
            get
            {
                if (!IsReadable)
                    throw new ArgumentException("Property get method not found.");
                return Getter(instance);
            }
            set
            {
                if (!IsWritable)
                    throw new ArgumentException("Property set method not found.");
                Setter(instance, value);
            }
        }
        protected Accessor(Expression<Func<S, T>> memberSelector) //access not given to outside world
        {
            var prop = memberSelector.GetPropertyInfo();
            IsReadable = prop.CanRead;
            IsWritable = prop.CanWrite;
            AssignDelegate(IsReadable, ref Getter, prop.GetGetMethod());
            AssignDelegate(IsWritable, ref Setter, prop.GetSetMethod());
        }
        void AssignDelegate<K>(bool assignable, ref K assignee, MethodInfo assignor) where K : class
        {
            if (assignable)
                assignee = assignor.CreateDelegate<K>();
        }
    }
