    /// <summary>TODO</summary>
    public struct IO<TSource> : IEquatable<IO<TSource>> {
        /// <summary>Create a new instance of the class.</summary>
        public IO(Func<TSource> functor) : this() { _functor = functor; }
        /// <summary>Invokes the internal functor, returning the result.</summary>
        public TSource Invoke() => (_functor | Default)();
        /// <summary>Returns true exactly when the contained functor is not null.</summary>
        public bool HasValue => _functor != null;
        X<Func<TSource>> _functor { get; }
        static Func<TSource> Default => null;
    }
