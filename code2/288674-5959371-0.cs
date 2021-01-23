        static Func<string> getUser;
        public static IAsyncResult BeginGetUser(AsyncCallback callback, object state)
        {
            getUser = () =>
                {
                    Thread.Sleep(2000);
                    return "finished";
                };
            return getUser.BeginInvoke(callback, state);
        }
        public static string EndGetUser(IAsyncResult asyncResult)
        {
            return getUser.EndInvoke(asyncResult);
        }
