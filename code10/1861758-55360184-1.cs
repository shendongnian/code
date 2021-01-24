    object IDbSetCache.GetOrAddSet(IDbSetSource source, Type type)
    {
        CheckDisposed();
        if (_sets == null)
        {
            _sets = new Dictionary<Type, object>();
        }
        if (!_sets.TryGetValue(type, out var set))
        {
            set = source.Create(this, type);
            _sets[type] = set;
        }
        return set;
    }
