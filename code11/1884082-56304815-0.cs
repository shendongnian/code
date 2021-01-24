        public virtual IInternalSetAdapter Set(Type entityType)
        {
            entityType = ObjectContextTypeCache.GetObjectType(entityType);
            IInternalSetAdapter set;
            if (!_nonGenericSets.TryGetValue(entityType, out set))
            {
                // We need to create a non-generic DbSet instance here, which is actually an instance of InternalDbSet<T>.
                // The CreateInternalSet method does this and will wrap the new object either around an existing
                // internal set if one can be found from the generic sets cache, or else will create a new one.
                set = CreateInternalSet(
                    entityType, _genericSets.TryGetValue(entityType, out set) ? set.InternalSet : null);
                _nonGenericSets.Add(entityType, set);
            }
            return set;
        }
