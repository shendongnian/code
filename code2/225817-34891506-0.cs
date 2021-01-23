        public static void SuppressException<TSut>(this TSut value, Action<TSut> action) where TSut : class
        {
            try
            {
                action.Invoke(value);
            }
            catch (Exception)
            {
                //do nothing
            }
        }
