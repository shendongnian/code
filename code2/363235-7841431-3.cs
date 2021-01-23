    public class DynamicWrapper<T> : DynamicObject
    {
        public T Instance { get; private set; }
        public DynamicWrapper(T instance)
        {
            this.Instance = instance;
        }
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.ReturnType == typeof(T))
            {
                result = Instance;
                return true;
            }
            if (binder.ReturnType == typeof(T[]) && binder.Explicit)
            {
                result = new[] { Instance };
                return true;
            }
            return base.TryConvert(binder, out result);
        }
        public override string ToString()
        {
            return Convert.ToString(Instance);
        }
    }
