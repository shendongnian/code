     public static void ThrowsExceptionOfType<T>(Action action) where T: Exception
        {
            try
            {
                action();
            }
            catch (T)
            {
                return;
            }
            catch (Exception exp)
            {
                throw new Exception(string.Format("Assert failed. Expecting exception of type {0} but got {1}.", typeof(T).Name, exp.GetType().Name));
            }
            throw new Exception(string.Format("Assert failed. Expecting exception of type {0} but no exception was thrown.", typeof(T).Name));
        }
