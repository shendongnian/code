    public delegate bool TryGetValueFunc<TKey, TValue>(TKey key, out TValue value);
    public struct KeyedValueWrapper<TKey, TValue>
    {
        private bool _KeyHasBeenSet;
        private TKey _Key;
        private TryGetValueFunc<TKey, TValue> _TryGetValue;
        private Func<TKey, TValue> _CreateValue;
        #region Constructors
        public KeyedValueWrapper(TKey key)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _TryGetValue = null;
            _CreateValue = null;
        }
        public KeyedValueWrapper(TKey key, TryGetValueFunc<TKey, TValue> tryGetValue)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _TryGetValue = tryGetValue;
            _CreateValue = null;
        }
        public KeyedValueWrapper(TKey key, Func<TKey, TValue> createValue)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _TryGetValue = null;
            _CreateValue = createValue;
        }
        public KeyedValueWrapper(TKey key, TryGetValueFunc<TKey, TValue> tryGetValue, Func<TKey, TValue> createValue)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _TryGetValue = tryGetValue;
            _CreateValue = createValue;
        }
        public KeyedValueWrapper(TryGetValueFunc<TKey, TValue> tryGetValue)
        {
            _Key = default(TKey);
            _KeyHasBeenSet = false;
            _TryGetValue = tryGetValue;
            _CreateValue = null;
        }
        public KeyedValueWrapper(TryGetValueFunc<TKey, TValue> tryGetValue, Func<TKey, TValue> createValue)
        {
            _Key = default(TKey);
            _KeyHasBeenSet = false;
            _TryGetValue = tryGetValue;
            _CreateValue = createValue;
        }
        public KeyedValueWrapper(Func<TKey, TValue> createValue)
        {
            _Key = default(TKey);
            _KeyHasBeenSet = false;
            _TryGetValue = null;
            _CreateValue = createValue;
        }
        #endregion
        #region "Change" methods
        public KeyedValueWrapper<TKey, TValue> Change(TKey key)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, _TryGetValue, _CreateValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TKey key, TryGetValueFunc<TKey, TValue> tryGetValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, tryGetValue, _CreateValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TKey key, Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, _TryGetValue, createValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TKey key, TryGetValueFunc<TKey, TValue> tryGetValue, Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, tryGetValue, createValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TryGetValueFunc<TKey, TValue> tryGetValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(_Key, tryGetValue, _CreateValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TryGetValueFunc<TKey, TValue> tryGetValue, Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(_Key, tryGetValue, createValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(_Key, _TryGetValue, createValue);
        }
        #endregion
        public TValue Value
        {
            get
            {
                if (!_KeyHasBeenSet)
                    throw new InvalidOperationException("A key must be specified.");
                if (_TryGetValue == null)
                    throw new InvalidOperationException("A \"try get value\" delegate must be specified.");
                // try to find a value in the given dictionary using the given key
                TValue value;
                if (!_TryGetValue(_Key, out value))
                {
                    if (_CreateValue == null)
                        throw new InvalidOperationException("A \"create value\" delegate must be specified.");
                    // if not found, create a value
                    value = _CreateValue(_Key);
                }
                // then return that value
                return value;
            }
        }
    }
    class Foo
    {
        public string ID { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Foo>();
            Func<string, Foo> createValue = (key) =>
            {
                var foo = new Foo { ID = key };
                dictionary.Add(key, foo);
                return foo;
            };
            // this wrapper object is not useable, since no key has been specified for it yet
            var wrapper = new KeyedValueWrapper<string, Foo>(dictionary.TryGetValue, createValue);
            // create wrapper1 based on the wrapper object but changing the key to "ABC"
            var wrapper1 = wrapper.Change("ABC");
            var wrapper2 = wrapper1;
            Foo foo1 = wrapper1.Value;
            Foo foo2 = wrapper2.Value;
            Console.WriteLine("foo1 and foo2 are equal? {0}", object.ReferenceEquals(foo1, foo2));
            // Output: foo1 and foo2 are equal? True
            // create wrapper1 based on the wrapper object but changing the key to "BCD"
            var wrapper3 = wrapper.Change("BCD");
            var wrapper4 = wrapper3;
            Foo foo3 = wrapper3.Value;
            dictionary = new Dictionary<string, Foo>(); // throw a curve ball by reassigning the dictionary variable
            Foo foo4 = wrapper4.Value;
            Console.WriteLine("foo3 and foo4 are equal? {0}", object.ReferenceEquals(foo3, foo4));
            // Output: foo3 and foo4 are equal? True
            Console.WriteLine("foo1 and foo3 are equal? {0}", object.ReferenceEquals(foo1, foo3));
            // Output: foo1 and foo3 are equal? False
        }
    }
