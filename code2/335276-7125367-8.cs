    public static class ExceptionHelper
    {
        public static void TryNTimesAndThenThrow(Action statement, int retryCount)
        {
            bool keepTrying = false;
            do
            {
                try
                {
                    statement();
                    keepTrying = false;
                }
                catch (Exception)
                {
                    if (retryCount > 0)
                    {
                        keepTrying = true;
                        retryCount--;
                    }
                    else
                    {
                        // If it doesn't work here, assume it's broken and rethrow
                        throw;
                    }
                }
            } while (keepTrying)
        }
    }
