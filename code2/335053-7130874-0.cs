        public static Action<Action<T>, Action<Exception>> AsyncExecute<T>(Action<AsyncCallback> begin, Func<IAsyncResult, T> end)
        {
            return (success, fail) =>
            {
                AsyncCallback cb = (ar) =>
                {
                    try
                    {
                        success(end(ar));
                    }
                    catch (Exception err)
                    {
                        fail(err);
                    }
                };
                begin(cb);
            };
        }
