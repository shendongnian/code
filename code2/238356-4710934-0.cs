    IEnumerable<int> GetFoo()
    {
        for (int i = -10; i < 10; i++)
        {
            Exception ex = null;
            try
            {
                int result = 0;
                try
                {
                    result = 10 / i;
                }
                catch (Exception e) // Don't normally do this!
                {
                    ex = e;
                    throw;
                }
                yield return result;
            }
            finally
            {
                if (ex != null)
                {
                    // Use ex here
                }
            }
        }
    }
