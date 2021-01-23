        protected TResult DoWrapped<TResult>(Func<TResult> action)
        {
            try
            {
                return action();
            }
            catch (Exception)
            {
                // Do something
                throw;
            }
        }
