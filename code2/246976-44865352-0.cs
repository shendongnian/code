        public static void Ignore<T>(Action a) where T : Exception
        {
            try
            {
                a();
            }
            catch (T)
            {
            }
        }
