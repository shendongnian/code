        public bool Remove(T item)
        {
            Transact(() => _session.Delete(item));
            return true;
        }
