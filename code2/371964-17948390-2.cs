        public static int GetInteger(object o, int defaultValue)
        {
            try
            {
                GetValue<int>(o, ref defaultValue);
                return defaultValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
