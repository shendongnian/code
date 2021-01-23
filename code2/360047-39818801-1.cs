    public interface IRetainingComparer<T> : IEqualityComparer<T>
    {
        T Key { get; }
        void ClearKeyCache();
    }
    /// <summary>
    /// An <see cref="IEqualityComparer{T}"/> that retains the last key that successfully passed <see cref="IEqualityComparer{T}.Equals(T,T)"/>.
    /// This class relies on the fact that <see cref="HashSet{T}"/> calls the <see cref="IEqualityComparer{T}.Equals(T,T)"/> with the first parameter
    /// being an existing element and the second parameter being the one passed to the initiating call to <see cref="HashSet{T}"/> (eg. <see cref="HashSet{T}.Contains(T)"/>).
    /// </summary>
    /// <typeparam name="T">The type of object being compared.</typeparam>
    /// <remarks>This class is thread-safe but may should not be used with any sort of parallel access (PLINQ).</remarks>
    public class RetainingEqualityComparerObject<T> : IRetainingComparer<T> where T : class
    {
        private readonly IEqualityComparer<T> _comparer;
        [ThreadStatic]
        private static WeakReference<T> _retained;
        public RetainingEqualityComparerObject(IEqualityComparer<T> comparer)
        {
            _comparer = comparer;
        }
        /// <summary>
        /// The retained instance on side 'a' of the <see cref="Equals"/> call which successfully met the equality requirement agains side 'b'.
        /// </summary>
        /// <remarks>Uses a <see cref="WeakReference{T}"/> so unintended memory leaks are not encountered.</remarks>
        public T Key
        {
            get
            {
                T retained;
                return _retained == null ? null : _retained.TryGetTarget(out retained) ? retained : null;
            }
        }
        /// <summary>
        /// Sets the retained <see cref="Key"/> to the default value.
        /// </summary>
        /// <remarks>This should be called prior to performing an operation that calls <see cref="Equals"/>.</remarks>
        public void ClearKeyCache()
        {
            _retained = _retained ?? new WeakReference<T>(null);
            _retained.SetTarget(null);
        }
        /// <summary>
        /// Test two objects of type <see cref="T"/> for equality retaining the object if successful.
        /// </summary>
        /// <param name="a">An instance of <see cref="T"/>.</param>
        /// <param name="b">A second instance of <see cref="T"/> to compare against <paramref name="a"/>.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are equal, false otherwise.</returns>
        public bool Equals(T a, T b)
        {
            if (!_comparer.Equals(a, b))
            {
                return false;
            }
            _retained = _retained ?? new WeakReference<T>(null);
            _retained.SetTarget(a);
            return true;
        }
        /// <summary>
        /// Gets the hash code value of an instance of <see cref="T"/>.
        /// </summary>
        /// <param name="o">The instance of <see cref="T"/> to obtain a hash code from.</param>
        /// <returns>The hash code value from <paramref name="o"/>.</returns>
        public int GetHashCode(T o)
        {
            return _comparer.GetHashCode(o);
        }
    }
    
    /// <summary>
    /// An <see cref="IEqualityComparer{T}"/> that retains the last key that successfully passed <see cref="IEqualityComparer{T}.Equals(T,T)"/>.
    /// This class relies on the fact that <see cref="HashSet{T}"/> calls the <see cref="IEqualityComparer{T}.Equals(T,T)"/> with the first parameter
    /// being an existing element and the second parameter being the one passed to the initiating call to <see cref="HashSet{T}"/> (eg. <see cref="HashSet{T}.Contains(T)"/>).
    /// </summary>
    /// <typeparam name="T">The type of object being compared.</typeparam>
    /// <remarks>This class is thread-safe but may should not be used with any sort of parallel access (PLINQ).</remarks>
    public class RetainingEqualityComparerStruct<T> : IRetainingComparer<T> where T : struct 
    {
        private readonly IEqualityComparer<T> _comparer;
        [ThreadStatic]
        private static T _retained;
        public RetainingEqualityComparerStruct(IEqualityComparer<T> comparer)
        {
            _comparer = comparer;
        }
        /// <summary>
        /// The retained instance on side 'a' of the <see cref="Equals"/> call which successfully met the equality requirement agains side 'b'.
        /// </summary>
        public T Key => _retained;
        /// <summary>
        /// Sets the retained <see cref="Key"/> to the default value.
        /// </summary>
        /// <remarks>This should be called prior to performing an operation that calls <see cref="Equals"/>.</remarks>
        public void ClearKeyCache()
        {
            _retained = default(T);
        }
        /// <summary>
        /// Test two objects of type <see cref="T"/> for equality retaining the object if successful.
        /// </summary>
        /// <param name="a">An instance of <see cref="T"/>.</param>
        /// <param name="b">A second instance of <see cref="T"/> to compare against <paramref name="a"/>.</param>
        /// <returns>True if <paramref name="a"/> and <paramref name="b"/> are equal, false otherwise.</returns>
        public bool Equals(T a, T b)
        {
            if (!_comparer.Equals(a, b))
            {
                return false;
            }
            _retained = a;
            return true;
        }
        /// <summary>
        /// Gets the hash code value of an instance of <see cref="T"/>.
        /// </summary>
        /// <param name="o">The instance of <see cref="T"/> to obtain a hash code from.</param>
        /// <returns>The hash code value from <paramref name="o"/>.</returns>
        public int GetHashCode(T o)
        {
            return _comparer.GetHashCode(o);
        }
    }
    /// <summary>
    /// Provides TryGetValue{T} functionality similar to that of <see cref="IDictionary{TKey,TValue}"/>'s implementation.
    /// </summary>
    public class ExtendedHashSet<T> : HashSet<T>
    {
        /// <summary>
        /// This class is guaranteed to wrap the <see cref="IEqualityComparer{T}"/> with one of the <see cref="IRetainingComparer{T}"/>
        /// implementations so this property gives convenient access to the interfaced comparer.
        /// </summary>
        private IRetainingComparer<T> RetainingComparer => (IRetainingComparer<T>)Comparer;
        /// <summary>
        /// Creates either a <see cref="RetainingEqualityComparerStruct{T}"/> or <see cref="RetainingEqualityComparerObject{T}"/>
        /// depending on if <see cref="T"/> is a reference type or a value type.
        /// </summary>
        /// <param name="comparer">(optional) The <see cref="IEqualityComparer{T}"/> to wrap. This will be set to <see cref="EqualityComparer{T}.Default"/> if none provided.</param>
        /// <returns>An instance of <see cref="IRetainingComparer{T}"/>.</returns>
        private static IRetainingComparer<T> Create(IEqualityComparer<T> comparer = null)
        {
            return (IRetainingComparer<T>) (typeof(T).IsValueType ? 
                Activator.CreateInstance(typeof(RetainingEqualityComparerStruct<>)
                    .MakeGenericType(typeof(T)), comparer ?? EqualityComparer<T>.Default)
                :
                Activator.CreateInstance(typeof(RetainingEqualityComparerObject<>)
                    .MakeGenericType(typeof(T)), comparer ?? EqualityComparer<T>.Default));
        }
        
        public ExtendedHashSet() : base(Create())
        {
        }
        public ExtendedHashSet(IEqualityComparer<T> comparer) : base(Create(comparer))
        {
        }
        public ExtendedHashSet(IEnumerable<T> collection) : base(collection, Create())
        {
        }
        public ExtendedHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer) : base(collection, Create(comparer))
        {
        }
        /// <summary>
        /// Attempts to find a key in the <see cref="HashSet{T}"/> and, if found, places the instance in <paramref name="original"/>.
        /// </summary>
        /// <param name="value">The key used to search the <see cref="HashSet{T}"/>.</param>
        /// <param name="original">
        /// The matched instance from the <see cref="HashSet{T}"/> which is not neccessarily the same as <paramref name="value"/>.
        /// This will be set to null for reference types or default(T) for value types when no match found.
        /// </param>
        /// <returns>True if a key in the <see cref="HashSet{T}"/> matched <paramref name="value"/>, False if no match found.</returns>
        public bool TryGetValue(T value, out T original)
        {
            var comparer = RetainingComparer;
            comparer.ClearKeyCache();
            if (Contains(value))
            {
                original = comparer.Key;
                return true;
            }
            original = default(T);
            return false;
        }
    }
    
    public static class HashSetExtensions
    {
        /// <summary>
        /// Attempts to find a key in the <see cref="HashSet{T}"/> and, if found, places the instance in <paramref name="original"/>.
        /// </summary>
        /// <param name="hashSet">The instance of <see cref="HashSet{T}"/> extended.</param>
        /// <param name="value">The key used to search the <see cref="HashSet{T}"/>.</param>
        /// <param name="original">
        /// The matched instance from the <see cref="HashSet{T}"/> which is not neccessarily the same as <paramref name="value"/>.
        /// This will be set to null for reference types or default(T) for value types when no match found.
        /// </param>
        /// <returns>True if a key in the <see cref="HashSet{T}"/> matched <paramref name="value"/>, False if no match found.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="hashSet"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="hashSet"/> does not have a <see cref="HashSet{T}.Comparer"/> of type <see cref="IRetainingComparer{T}"/>.
        /// </exception>
        public static bool TryGetValue<T>(this HashSet<T> hashSet, T value, out T original)
        {
            if (hashSet == null)
            {
                throw new ArgumentNullException(nameof(hashSet));
            }
            if (hashSet.Comparer.GetType().IsInstanceOfType(typeof(IRetainingComparer<T>)))
            {
                throw new ArgumentException($"HashSet must have an equality comparer of type '{nameof(IRetainingComparer<T>)}' to use this functionality", nameof(hashSet));
            }
            var comparer = (IRetainingComparer<T>)hashSet.Comparer;
            comparer.ClearKeyCache();
                
            if (hashSet.Contains(value))
            {
                original = comparer.Key;
                return true;
            }
            original = default(T);
            return false;
        }
    }
