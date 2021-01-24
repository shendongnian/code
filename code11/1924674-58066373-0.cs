        protected virtual TResult Transact<TResult>(Func<TResult> func)
        {
            if (_session.Transaction.IsActive)
                return func.Invoke();
            TResult result;
            using (var tx = _session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                result = func.Invoke();
                tx.Commit();
            }
            return result;
        }
        protected virtual void Transact(System.Action action)
        {
            Transact(() =>
            {
                action.Invoke();
                return false;
            });
        }
