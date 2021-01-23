        public static DateTime GetDateTime(object o, DateTime defaultValue)
        {
            try
            {
                GetValue<DateTime>(o, ref defaultValue);
                return defaultValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
