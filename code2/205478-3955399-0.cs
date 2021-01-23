      try
            {
                Parallel.For(0, _workers.Length, i =>
                {
                    DoWork(i);
                });
            }
            catch (AggregateException ex)
            {
                // Assume we know what's going on with this particular exception.
                // Rethrow anything else. AggregateException.Handle provides
                // another way to express this. See later example.
                foreach (var e in ex.InnerExceptions)
                {
                    OnLogged(e.Message + e.StackTrace);
                }
            }
