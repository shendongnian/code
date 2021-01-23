    public class DelegateProperty<T>
    {
        #region Fields
        private readonly Func<T> _getter;
        private readonly Action<T> _setter;
        private Lazy<T> _lazy;
        #endregion
        #region Constructors
        public DelegateProperty(Func<T> getter, Action<T> setter)
        {
            _getter = getter;
            _setter = setter;
            _lazy = new Lazy<T>(getter);
        }
        #endregion
        #region Properties
        public T Value
        {
            get { return _lazy.Value; }
            set
            {
                _setter(value);
                _lazy = new Lazy<T>(_getter);
            }
        }
        #endregion
        #region Operators
        public static implicit operator T(DelegateProperty<T> prop)
        {
            return prop.Value; 
        }
        #endregion
    }
