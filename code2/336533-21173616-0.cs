    public static List<T> ToList_DeadlockRetry<T>(this IEnumerable<T> source, int retryAttempts = 5)
    {
        while (retryAttempts > 0)
        {
            try
            {
                return source.ToList();
            }
            catch (SqlException ex)
            {
                retryAttempts--;
                if (retryAttempts == 0)
                {
                    throw ex;
                }
            }
        }
    }
