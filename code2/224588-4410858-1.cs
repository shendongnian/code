    public struct KeyedValueWrapper<TKey, TValue>
    {
        private bool _KeyHasBeenSet;
        private TKey _Key;
        private IDictionary<TKey, TValue> _Dictionary;
        private Func<TKey, TValue> _CreateValue;
        #region Constructors
        public KeyedValueWrapper(TKey key)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _Dictionary = null;
            _CreateValue = null;
        }
        public KeyedValueWrapper(TKey key, IDictionary<TKey, TValue> dictionary)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _Dictionary = dictionary;
            _CreateValue = null;
        }
        public KeyedValueWrapper(TKey key, Func<TKey, TValue> createValue)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _Dictionary = null;
            _CreateValue = createValue;
        }
        public KeyedValueWrapper(TKey key, IDictionary<TKey, TValue> dictionary, Func<TKey, TValue> createValue)
        {
            _Key = key;
            _KeyHasBeenSet = true;
            _Dictionary = dictionary;
            _CreateValue = createValue;
        }
        public KeyedValueWrapper(IDictionary<TKey, TValue> dictionary)
        {
            _Key = default(TKey);
            _KeyHasBeenSet = false;
            _Dictionary = dictionary;
            _CreateValue = null;
        }
        public KeyedValueWrapper(IDictionary<TKey, TValue> dictionary, Func<TKey, TValue> createValue)
        {
            _Key = default(TKey);
            _KeyHasBeenSet = false;
            _Dictionary = dictionary;
            _CreateValue = createValue;
        }
        public KeyedValueWrapper(Func<TKey, TValue> createValue)
        {
            _Key = default(TKey);
            _KeyHasBeenSet = false;
            _Dictionary = null;
            _CreateValue = createValue;
        }
        #endregion
        #region "Change" methods
        public KeyedValueWrapper<TKey, TValue> Change(TKey key)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, _Dictionary, _CreateValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TKey key, IDictionary<TKey, TValue> dictionary)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, dictionary, _CreateValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TKey key, Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, _Dictionary, createValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(TKey key, IDictionary<TKey, TValue> dictionary, Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(key, dictionary, createValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(IDictionary<TKey, TValue> dictionary)
        {
            return new KeyedValueWrapper<TKey, TValue>(_Key, dictionary, _CreateValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(IDictionary<TKey, TValue> dictionary, Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(_Key, dictionary, createValue);
        }
        public KeyedValueWrapper<TKey, TValue> Change(Func<TKey, TValue> createValue)
        {
            return new KeyedValueWrapper<TKey, TValue>(_Key, _Dictionary, createValue);
        }
        #endregion
        public TValue Value
        {
            get
            {
                if (!_KeyHasBeenSet)
                    throw new InvalidOperationException("A key must be specified.");
                if (_Dictionary == null)
                    throw new InvalidOperationException("A dictionary must be specified.");
                // try to find a value in the given dictionary using the given key
                TValue value;
                if (!_Dictionary.TryGetValue(_Key, out value))
                {
                    if (_CreateValue == null)
                        throw new InvalidOperationException("A \"create value\" delegate must be specified.");
                    // if not found, create a value and add it to the dictionary
                    value = _CreateValue(_Key);
                    _Dictionary.Add(_Key, value);
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
            // this wrapper object is not useable, since no key has been specified for it yet
            var wrapper = new KeyedValueWrapper<string, Foo>(new Dictionary<string, Foo>(), (key) => new Foo { ID = key });
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
            Foo foo4 = wrapper4.Value;
            Console.WriteLine("foo3 and foo4 are equal? {0}", object.ReferenceEquals(foo3, foo4));
            // Output: foo3 and foo4 are equal? True
            Console.WriteLine("foo1 and foo3 are equal? {0}", object.ReferenceEquals(foo1, foo3));
            // Output: foo1 and foo3 are equal? False
            // Counter-example: manipulating the dictionary instance that was provided to the wrapper can disrupt expected behavior
            var dictionary = new Dictionary<string, Foo>();
            var wrapper5 = wrapper.Change("CDE", dictionary);
            var wrapper6 = wrapper5;
            Foo foo5 = wrapper5.Value;
            dictionary.Clear();
            Foo foo6 = wrapper6.Value;
            // one might expect this to be true:
            Console.WriteLine("foo5 and foo6 are equal? {0}", object.ReferenceEquals(foo5, foo6));
            // Output: foo5 and foo6 are equal? False
        }
    }
