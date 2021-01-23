        private static void GetValue<T>(object o, ref T defaultValue)
        {
            try
            {
                if (defaultValue == null)
                {
                    throw new Exception("Default value cannot be null");
                }
                else if (o != null)
                {
                    if ((o is T))
                    {
                        defaultValue = (T)o;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
