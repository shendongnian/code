    //
    
        private T AttemptActionReturnObject<T>(Func<T> action)
                {
                    var attemptCount = 0;
        
                    do
                    {
                        attemptCount++;
                        try
                        {
                            return action();
                        }
                        catch (MySqlException ex)
                        {
                            if (attemptCount <= DB_DEADLOCK_RETRY_COUNT)
                            {
                                switch (ex.Number)
                                {
                                    case 1205: //(ER_LOCK_WAIT_TIMEOUT) Lock wait timeout exceeded
                                    case 1213: //(ER_LOCK_DEADLOCK) Deadlock found when trying to get lock
                                        Thread.Sleep(attemptCount*1000);
                                        break;
                                    default:
                                        throw;
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    } while (true);
                }
