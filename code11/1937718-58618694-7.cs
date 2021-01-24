    public bool Remove(TKey key)
    {
        if (key == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
        }
        if (_buckets != null)
        {
            Debug.Assert(_entries != null, "entries should be non-null");
            uint collisionCount = 0;
            uint hashCode = (uint)(_comparer?.GetHashCode(key) ?? key.GetHashCode());
            ref int bucket = ref GetBucket(hashCode);
            Entry[]? entries = _entries;
            int last = -1;
            // Value in buckets is 1-based
            int i = bucket - 1;
            while (i >= 0)
            {
                ref Entry entry = ref entries[i];
                if (entry.hashCode == hashCode && (_comparer?.Equals(entry.key, key) ?? EqualityComparer<TKey>.Default.Equals(entry.key, key)))
                {
                    if (last < 0)
                    {
                        // Value in buckets is 1-based
                        bucket = entry.next + 1;
                    }
                    else
                    {
                        entries[last].next = entry.next;
                    }
                    Debug.Assert((StartOfFreeList - _freeList) < 0, "shouldn't underflow because max hashtable length is MaxPrimeArrayLength = 0x7FEFFFFD(2146435069) _freelist underflow threshold 2147483646");
                    entry.next = StartOfFreeList - _freeList;
                    if (RuntimeHelpers.IsReferenceOrContainsReferences<TKey>())
                    {
                        entry.key = default!;
                    }
                    if (RuntimeHelpers.IsReferenceOrContainsReferences<TValue>())
                    {
                        entry.value = default!;
                    }
                    _freeList = i;
                    _freeCount++;
                    return true;
                }
                last = i;
                i = entry.next;
                collisionCount++;
                if (collisionCount > (uint)entries.Length)
                {
                    // The chain of entries forms a loop; which means a concurrent update has happened.
                    // Break out of the loop and throw, rather than looping forever.
                    ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
                }
            }
        }
        return false;
    }
